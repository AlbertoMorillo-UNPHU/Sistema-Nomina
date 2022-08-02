using Microsoft.EntityFrameworkCore;
using SistemaNomina.Data;
using SistemaNomina.Models;
using SistemaNomina.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaNomina.Services
{
	public class TaxCalculationService
	{
		public async Task<IEnumerable<TaxPercentage>> GetTaxPercentages()
		{
			using (var db = new ApplicationDbContext())
			{
				return await db.TaxPercentages.ToListAsync();
			}
		}

		public decimal CalculateTaxableIncome(Employee employee, decimal grossPay)
		{
			// reduce Insurance
			var taxableIncome = grossPay - employee.ARS;

			// reduce 401k Pre tax

			taxableIncome = taxableIncome - Calculate401KAmount(employee, grossPay);

			// reduce w4 withholding allowances
			taxableIncome = taxableIncome - CalculateW4AllowanceAmount(employee);

			// return 0 if negative
			return taxableIncome < 0 ? 0 : taxableIncome;

		}

		// function to calculate w4 allowances amount
		public decimal CalculateW4AllowanceAmount(Employee employee)
		{
			return employee.AFP * (decimal)168.80;
		}

		// function to calculate 401k savings amount
		public decimal Calculate401KAmount(Employee employee, decimal grossPay)
		{
			return Math.Round(grossPay * employee.AFP * (decimal)0.01, 2);
		}

		// function to calculate Fed tax amount
		public decimal CalculateFedTaxAmount(decimal taxableIncome)
		{
			// if taxable income < 500 no tax
			if (taxableIncome < 500)
			{
				return 0;
			}

			// if taxable income > 500 && < 5000 = 3% tax
			if (taxableIncome > 500 && taxableIncome < 5000)
			{
				return Math.Round(taxableIncome * (decimal)0.03, 2);
			}

			// if taxable income >= 5000 && < 10,000 = 7% tax
			if (taxableIncome >= 5000 && taxableIncome < 10000)
			{
				return Math.Round(taxableIncome * (decimal)0.07, 2);
			}

			// everything else deduct standard fed tax percent
			using (var db = new ApplicationDbContext())
			{
				var standardFedTax = db.TaxPercentages.First(x => x.TaxCode == "FED").Percent;
				return Math.Round(taxableIncome * standardFedTax * (decimal)0.01, 2);
			}
		}

		// function to calculate State tax amount
		public decimal CalculateStateTaxAmount(decimal taxableIncome, string stateCode)
		{
			// if taxable income < 500 no tax
			if (taxableIncome < 500)
			{
				return 0;
			}

			// if taxable income > 500 && < 5000 = 1% tax
			if (taxableIncome > 500 && taxableIncome < 5000)
			{
				return Math.Round(taxableIncome * (decimal)0.01, 2);
			}

			// if taxable income >= 5000 && < 10,000 = 1.5% tax
			if (taxableIncome >= 5000 && taxableIncome < 10000)
			{
				return Math.Round(taxableIncome * (decimal)0.015, 2);
			}

			// everything else deduct standard state tax percent
			using (var db = new ApplicationDbContext())
			{
				var standardStateTax = db.TaxPercentages.First(x => x.TaxCode == stateCode).Percent;
				return Math.Round(taxableIncome * standardStateTax * (decimal)0.01, 2);
			}
		}

		// function to calculate Social security tax amount
		public decimal CalculateSocialTaxAmount(decimal grossPay)
		{
			// deduct standard social security tax percent
			using (var db = new ApplicationDbContext())
			{
				var standardSocialTax = db.TaxPercentages.First(x => x.TaxCode == "SOCIAL").Percent;
				return Math.Round(grossPay * standardSocialTax * (decimal)0.01, 2);
			}
		}

		// function to calculate Medicare security tax amount
		public decimal CalculateMedicareTaxAmount(decimal grossPay)
		{
			// deduct standard social security tax percent
			using (var db = new ApplicationDbContext())
			{
				var standardMedicareTax = db.TaxPercentages.First(x => x.TaxCode == "MEDICARE").Percent;
				return Math.Round(grossPay * standardMedicareTax * (decimal)0.01, 2);
			}
		}


		// calculate net pay after all deductions
		public decimal CalculateNetPay(Employee employee, decimal grosspay)
		{
			// calculate taxable income
			var taxableIncome = CalculateTaxableIncome(employee, grosspay);

			// calculate 401k amount
			var retirement = Calculate401KAmount(employee, grosspay);

			// calculate all taxes
			var fedTax = CalculateFedTaxAmount(taxableIncome);
			var socialTax = CalculateSocialTaxAmount(grosspay);
			var medicareTax = CalculateMedicareTaxAmount(grosspay);

			// reduce all deductions
			var finalpay = grosspay - (fedTax + socialTax + medicareTax + employee.AFP + retirement);

			return Math.Round(finalpay, 2);
		}

		
		public TaxModels.Deductions GetDeductions(Employee employee, decimal grosspay)
		{		
			var taxableIncome = CalculateTaxableIncome(employee, grosspay);
		
			var w4Allowances = CalculateW4AllowanceAmount(employee);

			var retirement = Calculate401KAmount(employee, grosspay);

			var fedTax = CalculateFedTaxAmount(taxableIncome);
			var socialTax = CalculateSocialTaxAmount(grosspay);
			var medicareTax = CalculateMedicareTaxAmount(grosspay);

			var finalpay = grosspay - (fedTax + socialTax + medicareTax + employee.ARS + retirement);

			return new TaxModels.Deductions
			{
				TaxableIncome = taxableIncome,
				ARS = employee.ARS,
				AFP = w4Allowances,
				ISR = fedTax,
				INFOTEP = fedTax,
				TSS = socialTax,
				ARL = medicareTax,
				NetPay = finalpay
			};
		}

	}
}

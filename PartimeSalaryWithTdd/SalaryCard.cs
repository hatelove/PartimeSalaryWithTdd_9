using System;
using PartimeSalaryWithTdd.Utility;

namespace PartimeSalaryWithTdd
{
    public class SalaryCard
    {
        public SalaryCard()
        {
        }

        public int HourlySalary { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public double CalculateSalary()
        {
            double workingHour = GetWorkingHour();
            return workingHour * this.HourlySalary;
        }

        private double GetWorkingHour()
        {
            var morningHour = DateTimeHelper.TotalHours(this.StartTime,
                new DateTime(this.StartTime.Year, this.StartTime.Month, this.StartTime.Day, 12, 0, 0));

            var afternoonHour = DateTimeHelper.TotalHours(
                new DateTime(this.EndTime.Year, this.EndTime.Month, this.EndTime.Day, 13, 0, 0), this.EndTime);

            return morningHour + afternoonHour;
        }
    }
}
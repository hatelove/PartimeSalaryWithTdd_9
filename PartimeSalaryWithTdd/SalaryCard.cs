using PartimeSalaryWithTdd.Utility;
using System;

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
        public double FirstOverTimeRatio { get; set; }
        public int SecondOverTimeRatio { get; set; }

        public double CalculateSalary()
        {
            double workingHour = GetWorkingHour();
            var isNormalWork = workingHour <= 8;
            if (isNormalWork)
            {
                return workingHour * this.HourlySalary;
            }
            else
            {
                var normalPay = 8 * this.HourlySalary;

                var overtimePay = GetOvertimePay(workingHour);

                return normalPay + overtimePay;
            }
        }

        private double GetOvertimePay(double workingHour)
        {
            var overtimeHour = workingHour - 8;
            if (overtimeHour <= 2)
            {
                var overtimePay = overtimeHour * this.HourlySalary * this.FirstOverTimeRatio;
                return overtimePay;
            }
            else
            {
                var firstOvertimePay = 2 * this.HourlySalary * this.FirstOverTimeRatio;

                var secondOvertimeHour = (overtimeHour - 2);
                if (secondOvertimeHour > 2)
                {
                    secondOvertimeHour = 2;
                }

                var secondOvertimePay = secondOvertimeHour * this.HourlySalary * this.SecondOverTimeRatio;
                return firstOvertimePay + secondOvertimePay;

            }

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
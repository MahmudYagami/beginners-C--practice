using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace _1st_Lab_For_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Appointment> appointments = new List<Appointment>();

            bool addMoreAppointments = true;

            while (addMoreAppointments)
            {
                Console.WriteLine("Enter visit date (DD MM YYYY): ");
                string[] visitDateInput = Console.ReadLine().Split(' ');
                int day = int.Parse(visitDateInput[0]);
                int month = int.Parse(visitDateInput[1]);
                int year = int.Parse(visitDateInput[2]);
                Date visit = new Date(day, month, year);

                Console.WriteLine("Enter next visit date (DD MM YYYY): ");
                string[] nextVisitDateInput = Console.ReadLine().Split(' ');
                day = int.Parse(nextVisitDateInput[0]);
                month = int.Parse(nextVisitDateInput[1]);
                year = int.Parse(nextVisitDateInput[2]);
                Date nextVisit = new Date(day, month, year);

                Console.WriteLine("Enter patient ID: ");
                string patientId = Console.ReadLine();

                Console.WriteLine("Enter patient name: ");
                string patientName = Console.ReadLine();

                Console.WriteLine("Enter consultation fee: ");
                double consultationFee = double.Parse(Console.ReadLine());

                Appointment appointment = new Appointment(visit, nextVisit, patientId, patientName, consultationFee);
                appointments.Add(appointment);

                Console.WriteLine("Do you want to add another appointment? (yes/no)");
                string addMoreInput = Console.ReadLine();
                addMoreAppointments = (addMoreInput.ToLower() == "yes");
            }

            foreach (var appointment in appointments)
            {
                appointment.displayAppt();
            }

            Console.WriteLine("Enter patient ID (NRIC) to search: ");
            string searchPatientId = Console.ReadLine();
            bool found = false;
            foreach (var appointment in appointments)
            {
                if (appointment.NRIC == searchPatientId)
                {
                    appointment.displayAppt();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No appointments found for patient ID (NRIC): " + searchPatientId);
            }



            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace OOPSynoptic
{
    public class AppointmentRepository
    {
        private readonly DataClasses1DataContext AppointmentTagContext;

        public AppointmentRepository()
        {
            AppointmentTagContext = new DataClasses1DataContext(); 
        }


        public void addAppointment(Appointment a)
        {
            AppointmentTagContext.Appointments.InsertOnSubmit(a);
            AppointmentTagContext.SubmitChanges();
        }
        public Appointment GetAppointmentById(int id)
        {
            return AppointmentTagContext.Appointments.SingleOrDefault(a => a.Id == id);
        }
        public IQueryable<Appointment> getAppointments(bool past)
        {
            if (past)
            {
                return AppointmentTagContext.Appointments
                    .Where(a => a.Date < DateTime.Now)
                    .OrderByDescending(a => a.Date);
            }
            else
            {
                return AppointmentTagContext.Appointments
                    .Where(a => a.Date >= DateTime.Now)
                    .OrderBy(a => a.Date);
            }
        }
        public IQueryable<Appointment> searchAppointments(string keyword)
        {
            return AppointmentTagContext.Appointments
                .Where(a => a.Title.Contains(keyword) || a.Description.Contains(keyword));
        }
        public void deleteAppointment(int id)
        {
            var appointment = AppointmentTagContext.Appointments.SingleOrDefault(a => a.Id == id);
            if (appointment != null)
            {
                AppointmentTagContext.Appointments.DeleteOnSubmit(appointment);
                AppointmentTagContext.SubmitChanges();
            }
        }

        public IQueryable<Appointment> getAllAppointmentsByTag(int id)
        {
            return AppointmentTagContext.Appointments
                .Where(a => a.TagId == id);
        }

        //A class TagAppointmentsSummary was created so that I can collect all data for the method GetAppointmentsSummaryPerTag() and GetFilteredAppointmentsSummaryPerTag(datetime dt) in one class
        public class tagAppointmentsSummary
        {
            public int TagId { get; set; }
            public string TagTitle { get; set; }
            public int numberOfAppointments { get; set; }
        }
        public IEnumerable<tagAppointmentsSummary> GetAppointmentsSummaryPerTag()
        {
            var aptSummaryPerTag = AppointmentTagContext.Appointments
                .GroupBy(a => a.TagId)
                .Select(g => new tagAppointmentsSummary
                {
                    TagId = g.Key,
                    TagTitle = g.FirstOrDefault().Tag.Title,
                    numberOfAppointments = g.Count()
                })
                .OrderByDescending(s => s.numberOfAppointments);

            return aptSummaryPerTag;
        }
        public IQueryable<object> getFilteredAppointmentsSummaryPerTag(DateTime dt)
        {
            var filteredDate = dt.Date;

            var filterSummary = AppointmentTagContext.Appointments
                .Where(a => a.Date.Year == filteredDate.Year &&
                            a.Date.Month == filteredDate.Month &&
                            a.Date.Day == filteredDate.Day)
                .GroupBy(a => a.TagId)
                .Select(g => new
                {
                    TagTitle = g.FirstOrDefault().Tag.Title,
                    numberOfAppointments = g.Count()
                })
                .OrderByDescending(s => s.numberOfAppointments);

            return filterSummary;
        }
        public void updateTagOfAppointment(int appointmentId, int newTag)
        {
            var appointment = AppointmentTagContext.Appointments.FirstOrDefault(a => a.Id == appointmentId);

            if (appointment != null)
            {
                appointment.TagId = newTag;
                
            }
            else
            {
                Console.WriteLine("Sorry but your Appointment was not found");
            }
        }
    }
}
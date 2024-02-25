using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA2._3
{
   
        class Appointment
        {
            public static void main(string[] args) { }
            public Appointment(DateTime date)
            {
                Date = date;
                Details = new furtherAppointmentDetails();
            }

            public string Title { get; set; }
            public DateTime Date { get; set; }
            public int Id { get; set; }
            public furtherAppointmentDetails Details { get; }

            public void AddTag(Tag tag)
            {
                Tag.Add(tag);
            }

        }

        public class furtherAppointmentDetails
        {
            public string Description { get; set; }
            public string Location { get; set; }


        }
        //I added the class furtherAppointmentDetails to enable a composition relationship

    }


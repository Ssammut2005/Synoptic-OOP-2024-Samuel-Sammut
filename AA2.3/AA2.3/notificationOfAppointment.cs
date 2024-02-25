using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA2._3
{
    class notificationOfAppointment : Appointment
    {
        public EmailAddress Recipient { get; set; }


        public notificationOfAppointment(DateTime date, EmailAddress recipient) : base(date)
        {
            Recipient = recipient;
            sendNotification();
        }


        private void sendNotification()
        {
            Console.WriteLine("A Notification has been sent to " + Recipient.Recipient + " for the appointment:" + Title + " which is going to be held on the " + Date);

        }
    }
}

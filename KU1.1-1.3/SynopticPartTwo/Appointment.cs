using System.Collections.Generic;
using System;

public class Appointment
{
    private List<Appointment> appointments = new List<Appointment>();

    public Appointment(string title, DateTime date)
    {
        Date = date;
        Title = title;
    }

    public string Title { get; set; }
    public DateTime Date { get; set; }

    public int Id { get; set; }

    public int TagFk { get; set; }

    //Mehtod to add new Appintmens

    public void addNewAppointment(Appointment a)
    {
        if (a.Date > DateTime.Now)
        {
            appointments.Add(a);
        }
        else
        {
            Console.WriteLine("You have enetered a date in the past and therefore the appointment could not be created");
        }
    }


}

public class Calendar
{
    private string user;
    private string title;
    private DateTime startDate;

    public string User
    {
        get { return user; }
        private set { user = value; }
    }

    public string Title
    {
        get { return title; }
        private set { title = value; }
    }

    public DateTime StartDate
    {
        get { return startDate; }
        private set
        {
            if (value > DateTime.Now)
            {
                throw new Exception("Invalid Date");
            }
            else
            {
                startDate = value;
            }
        }



    }

}
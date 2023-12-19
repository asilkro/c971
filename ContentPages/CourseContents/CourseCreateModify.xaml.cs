using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CourseTracker.Supplemental.Connection;
using SQLite;

namespace CourseTracker.ContentPages.CourseContents;

public partial class CourseCreateModify
{
    private string OperationType { get; set; }

    public static Term term { get; set; }


    private void DateSetup()
    {
        StartDate.MinimumDate= term.StartDate.Date;
        StartDate.MaximumDate = term.EndDate.Date;

        EndDate.MinimumDate = term.StartDate.MinimumDate;
        EndDate.MaximumDate = term.EndDate.MaximumDate;
    }
    public CourseCreateModify()
    {
        OperationType = "Create";
        InitializeComponent();

        DateSetup();

        Save.IsEnabled = false;
    }

    public CourseCreateModify(Models.Course course)
    {
        OperationType = "Modify";
        InitializeComponent();
        DateSetup();
        CourseName.Text = course.CourseName;
        CourseId.Text = course.CourseId;
        StartDate.Date = course.StartDate.Date;
        EndDate.Date = course.EndDate.Date;
        Status.Text = course.Status;
        Instructor.Text = course.InstructorName;
        CourseNotifications.IsToggled = course.CourseNotifications;
        CourseNotes.Text = course.Notes;
        Save.IsEnabled = true;
    }

    private void CourseNotifications_OnToggled(object sender, ToggledEventArgs e)
    {
        throw new NotImplementedException();
    }
}
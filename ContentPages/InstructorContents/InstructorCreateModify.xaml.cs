using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.ContentPages.InstructorContents;

public partial class InstructorCreateModify
{
    
    public InstructorCreateModify()
    {
        InitializeComponent();
        Save.IsEnabled = false;
    }

    public InstructorCreateModify(Models.Instructor instructor)
    {
        InitializeComponent();
        InstructorName.Text = instructor.InstructorName;
        InstructorEmail.Text = instructor.InstructorEmail;
        InstructorPhone.Text = instructor.InstructorPhone;
        Save.IsEnabled = true;
    }
}
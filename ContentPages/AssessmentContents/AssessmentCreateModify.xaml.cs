using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.ContentPages.AssessmentContents;

public partial class AssessmentCreateModify
{
    private string operation;
    public AssessmentCreateModify()
    {
        operation = "Create";
        InitializeComponent();
        Save.IsEnabled = false;
    }

    public AssessmentCreateModify(Models.Assessment assessment)
    {
        operation = "Modify";
        InitializeComponent();
        AssessmentName.Text = assessment.AssessmentName;
        AssessmentType.Text = assessment.AssessmentType;
        AssessmentStartDate.Date = assessment.AssessmentStartDate;
        AssessmentEndDate.Date = assessment.AssessmentEndDate;
        CourseId.Text = assessment.RelatedCourseId;
        AssessmentId.Text = assessment.AssessmentId;
        Save.IsEnabled = true;
    }
}
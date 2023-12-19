using CourseTracker.Models;

namespace CourseTracker.ViewModels;

public partial class AssessmentView : ContentView
{
    public static readonly BindableProperty AssessmentIdProperty =
        BindableProperty.Create(nameof(AssessmentId), typeof(string), typeof(AssessmentView), string.Empty);

    public string AssessmentId
    {
        get => (string)GetValue(AssessmentIdProperty);
        set => SetValue(AssessmentIdProperty, value);
    }

    public static readonly BindableProperty AssessmentNameProperty =
        BindableProperty.Create(nameof(AssessmentName), typeof(string), typeof(AssessmentView), string.Empty);

    public string AssessmentName
    {
        get => (string)GetValue(AssessmentNameProperty);
        set => SetValue(AssessmentNameProperty, value);
    }

    public static readonly BindableProperty AssessmentTypeProperty =
        BindableProperty.Create(nameof(AssessmentType), typeof(Assessment.AssessmentType), typeof(AssessmentView), Assessment.AssessmentType.Undefined);

    public Assessment.AssessmentType AssessmentType
    {
        get => (Assessment.AssessmentType)GetValue(AssessmentTypeProperty);
        set => SetValue(AssessmentTypeProperty, value);
    }

    public static readonly BindableProperty AssessmentStartDateProperty =
        BindableProperty.Create(nameof(AssessmentStartDateProperty), typeof(DateTime), typeof(AssessmentView), DateTime.Today);

    public DateTime AssessmentStartDate
    {
        get => (DateTime)GetValue(AssessmentStartDateProperty);
        set => SetValue(AssessmentStartDateProperty, value);
    }

    public static readonly BindableProperty AssessmentEndDateProperty =
        BindableProperty.Create(nameof(AssessmentEndDateProperty), typeof(DateTime), typeof(AssessmentView), DateTime.Today.AddDays(30));

    public DateTime AssessmentEndDate
    {
        get => (DateTime)GetValue(AssessmentEndDateProperty);
        set => SetValue(AssessmentEndDateProperty, value);
    }

    public static readonly BindableProperty CourseIdProperty =
        BindableProperty.Create(nameof(CourseId), typeof(string), typeof(AssessmentView), string.Empty);

    public string CourseId
    {
        get => (string)GetValue(CourseIdProperty);
        set => SetValue(CourseIdProperty, value);
    }

    public AssessmentView()
    {
        InitializeComponent();
    }

    public AssessmentView(Assessment assessment)
    {
        InitializeComponent();
        AssessmentId = assessment.AssessmentId;
        AssessmentName = assessment.AssessmentName;
        AssessmentType = assessment.AssessmentType;
        AssessmentStartDate = assessment.AssessmentStartDate;
        AssessmentEndDate = assessment.AssessmentEndDate;
        CourseId = assessment.CourseId;
    }
}
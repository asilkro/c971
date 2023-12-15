using CourseTracker.Models;

namespace CourseTracker.ViewModels;

public partial class CourseView : ContentView
{
    #region Properties

    public static readonly BindableProperty CourseIdProperty =
        BindableProperty.Create(nameof(CourseId), typeof(string), typeof(CourseView), string.Empty);

    public string CourseId
    {
        get => (string)GetValue(CourseIdProperty);
        set => SetValue(CourseIdProperty, value);
    }

    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title), typeof(string), typeof(CourseView), string.Empty);

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly BindableProperty StartDateProperty =
        BindableProperty.Create(nameof(StartDate), typeof(DateTime), typeof(CourseView), DateTime.Today);

    public DateTime StartDate
    {
        get => (DateTime)GetValue(StartDateProperty);
        set => SetValue(StartDateProperty, value);
    }

    public static readonly BindableProperty EndDateProperty =
        BindableProperty.Create(nameof(EndDate), typeof(DateTime), typeof(CourseView), DateTime.Today.AddDays(30));

    public DateTime EndDate
    {
        get => (DateTime)GetValue(EndDateProperty);
        set => SetValue(EndDateProperty, value);
    }

    public static readonly BindableProperty StatusProperty =
        BindableProperty.Create(nameof(Status), typeof(Course.CourseStatuses), typeof(CourseView), Course.CourseStatuses.undefined);

    public Course.CourseStatuses Status
    {
        get => (Course.CourseStatuses)GetValue(StatusProperty);
        set => SetValue(StatusProperty, value);
    }

    public static readonly BindableProperty InstructorNameProperty =
        BindableProperty.Create(nameof(InstructorName), typeof(string), typeof(CourseView), string.Empty);

    public string InstructorName
    {
        get => (string)GetValue(InstructorNameProperty);
        set => SetValue(InstructorNameProperty, value);
    }

    public static readonly BindableProperty InstructorEmailProperty =
        BindableProperty.Create(nameof(InstructorEmail), typeof(string), typeof(CourseView), string.Empty);

    public string InstructorEmail
    {
        get => (string)GetValue(InstructorEmailProperty);
        set => SetValue(InstructorEmailProperty, value);
    }

    public static readonly BindableProperty InstructorPhoneProperty =
        BindableProperty.Create(nameof(InstructorPhone), typeof(string), typeof(CourseView), string.Empty);

    public string InstructorPhone
    {
        get => (string)GetValue(InstructorPhoneProperty);
        set => SetValue(InstructorPhoneProperty, value);
    }

    public static readonly BindableProperty NotesProperty =
        BindableProperty.Create(nameof(Notes), typeof(string), typeof(CourseView), string.Empty);

    public string Notes
    {
        get => (string)GetValue(NotesProperty); 
        set => SetValue(NotesProperty, value);
    }
    #endregion

    public CourseView()
    {
        InitializeComponent();
    }
}
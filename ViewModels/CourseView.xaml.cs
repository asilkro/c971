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

    public static readonly BindableProperty TermIdProperty =
        BindableProperty.Create(nameof(TermId), typeof(string), typeof(CourseView), string.Empty);

    public string TermId
    {
        get => (string)GetValue(TermIdProperty);
        set => SetValue(TermIdProperty, value);
    }

    public static readonly BindableProperty CourseNameProperty =
        BindableProperty.Create(nameof(CourseName), typeof(string), typeof(CourseView), string.Empty);

    public string CourseName
    {
        get => (string)GetValue(CourseNameProperty);
        set => SetValue(CourseNameProperty, value);
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
        BindableProperty.Create(nameof(Status), typeof(string), typeof(CourseView), "Undefined");

    public string Status
    {
        get => (string)GetValue(StatusProperty);
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

    public static readonly BindableProperty CourseNotificationsProperty =
        BindableProperty.Create(nameof(CourseNotifications), typeof(bool), typeof(CourseView), true);

    public bool CourseNotifications
    {
        get => (bool)GetValue(CourseNotificationsProperty);
        set => SetValue(CourseNotificationsProperty, value);
    }

    #endregion

    public CourseView()
    {
        InitializeComponent();
    }

    public CourseView(Course course)
    {
        InitializeComponent();
        CourseId = course.CourseId;
        TermId = course.TermId;
        CourseName = course.CourseName;
        StartDate = course.StartDate;
        EndDate = course.EndDate;
        Status = course.Status;
        InstructorName = course.InstructorName;
        InstructorEmail = course.InstructorEmail;
        InstructorPhone = course.InstructorPhone;
        Notes = course.Notes;
        CourseNotifications = course.CourseNotifications;
    }
}
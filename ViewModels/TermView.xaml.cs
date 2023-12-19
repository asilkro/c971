using CourseTracker.Models;

namespace CourseTracker.ViewModels;

public partial class TermView
{
    public static readonly BindableProperty TermIdProperty =
        BindableProperty.Create(nameof(TermId), typeof(string), typeof(TermView), string.Empty);

    public string TermId
    {
        get => (string)GetValue(TermIdProperty);
        set => SetValue(TermIdProperty, value);
    }

    public static readonly BindableProperty TermNameProperty =
        BindableProperty.Create(nameof(TermName), typeof(string), typeof(TermView), string.Empty);

    public string TermName
    {
        get => (string)GetValue(TermNameProperty);
        set => SetValue(TermNameProperty, value);
    }

    public static readonly BindableProperty StartDateProperty =
        BindableProperty.Create(nameof(StartDate), typeof(DateTime), typeof(TermView), DateTime.Today);

    public DateTime StartDate
    {
        get => (DateTime)GetValue(StartDateProperty);
        set => SetValue(StartDateProperty, value);
    }

    public static readonly BindableProperty EndDateProperty =
        BindableProperty.Create(nameof(EndDate), typeof(DateTime), typeof(TermView), DateTime.Today.AddDays(30));

    public DateTime EndDate
    {
        get => (DateTime)GetValue(EndDateProperty);
        set => SetValue(EndDateProperty, value);
    }

    public static readonly BindableProperty CoursesProperty =
        BindableProperty.Create(nameof(Courses), typeof(List<Course>), typeof(TermView), new List<Course>());

    public List<Course> Courses
    {
        get => (List<Course>)GetValue(CoursesProperty);
        set => SetValue(CoursesProperty, value);
    }

    public static readonly BindableProperty NotesProperty =
        BindableProperty.Create(nameof(Notes), typeof(string), typeof(TermView), string.Empty);

    public string Notes
    {
        get => (string)GetValue(NotesProperty);
        set => SetValue(NotesProperty, value);
    }

    public TermView()
    {
        InitializeComponent();
    }

    public TermView(Term term)
    {
        InitializeComponent();
        TermId = term.TermId;
        TermName = term.TermName;
        StartDate = term.StartDate;
        EndDate = term.EndDate;
        Courses = term.Courses;
        Notes = term.Notes;
    }
}
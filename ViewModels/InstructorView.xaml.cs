namespace CourseTracker.ViewModels;

public partial class InstructorView
{
    public static readonly BindableProperty InstructorIdProperty =
        BindableProperty.Create(nameof(InstructorId), typeof(string), typeof(InstructorView), string.Empty);

    public string InstructorId
    {
        get => (string)GetValue(InstructorIdProperty);
        set => SetValue(InstructorIdProperty, value);
    }

    public static readonly BindableProperty InstructorNameProperty =
        BindableProperty.Create(nameof(InstructorName), typeof(string), typeof(InstructorView), string.Empty);

    public string InstructorName
    {
        get => (string)GetValue(InstructorNameProperty);
        set => SetValue(InstructorNameProperty, value);
    }

    public static readonly BindableProperty InstructorEmailProperty =
        BindableProperty.Create(nameof(InstructorEmail), typeof(string), typeof(InstructorView), string.Empty);

    public string InstructorEmail
    {
        get => (string)GetValue(InstructorEmailProperty);
        set => SetValue(InstructorEmailProperty, value);
    }

    public static readonly BindableProperty InstructorPhoneProperty =
        BindableProperty.Create(nameof(InstructorPhone), typeof(string), typeof(InstructorView), string.Empty);

    public string InstructorPhone
    {
        get => (string)GetValue(InstructorPhoneProperty);
        set => SetValue(InstructorPhoneProperty, value);
    }

    public InstructorView()
    {
        InitializeComponent();
    }

    public InstructorView(Models.Instructor instructor)
    {
        InitializeComponent();
        InstructorId = instructor.InstructorId;
        InstructorName = instructor.InstructorName;
        InstructorEmail = instructor.InstructorEmail;
        InstructorPhone = instructor.InstructorPhone;
    }
}
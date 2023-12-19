using CourseTracker.Supplemental;
using CourseTracker.ViewModels;

namespace CourseTracker.ContentPages;

public partial class Term
{
    private Connection _conn;
    private Models.Course _course;
    private Models.Term _term;

    public Term()
    {
        _term = new Models.Term();
        InitializeComponent();
        BindingContext = new TermView();
        var db = _conn.GetAsyncConnection();
        //TODO: Finish constructor
    }

    public async Task AddTerm(Models.Course course)
    {
        InitializeComponent();
        BindingContext = new TermView();
        var db = _conn.GetAsyncConnection();
        await db.InsertAsync(_term); //TODO: BUILD CONSTRUCTOR FROM INPUTS
        ((TermView)BindingContext).TermId = course.TermId;
    }

    public async Task UpdateTerm(Models.Course course)
    {
        InitializeComponent();
        BindingContext = new TermView();
        var db = _conn.GetAsyncConnection();
        await db.UpdateAsync(_term); //TODO: BUILD CONSTRUCTOR FROM INPUTS
        ((TermView)BindingContext).TermId = course.TermId;
    }

    public async Task DeleteTerm(Models.Course course)
    {
        InitializeComponent();
        BindingContext = new TermView();
        var db = _conn.GetAsyncConnection();
        await db.DeleteAsync(_term); //TODO: BUILD CONSTRUCTOR FROM INPUTS
        ((TermView)BindingContext).TermId = course.TermId;
    }

    private async void AddTerm_OnButtonClicked(object sender, EventArgs e)
    {
        _ = AddTerm(_course); //TODO: Make sure this can actually bind to a course
        await Navigation.PopAsync();
    }

    private async void UpdateTerm_OnButtonClicked(object sender, EventArgs e)
    {
        _ = UpdateTerm(_course); //TODO: Make sure this can actually bind to a course
        await Navigation.PopAsync();
    }

    private async void DeleteTerm_OnButtonClicked(object sender, EventArgs e)
    {
        _ = DeleteTerm(_course); //TODO: Make sure this can actually bind to a course
        await Navigation.PopAsync();
    }

}
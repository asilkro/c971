using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseTracker.Models;
using CourseTracker.Supplemental;
using CourseTracker.ViewModels;
using SQLite;

namespace CourseTracker.ContentPages;

public partial class Course : ContentPage
{
    private SQLiteAsyncConnection _conn;
    private Models.Course _course;

    public Course()
    {
        InitializeComponent();
        BindingContext = new CourseView();
        var conn = new Connection();
        var db = conn.GetAsyncConnection();
    }

    public async Task AddCourse(Term term)
    {
        InitializeComponent();
        BindingContext = new CourseView();
        var conn = new Connection();
        var db = conn.GetAsyncConnection();
        await db.InsertAsync(somecourse());
        ((CourseView)BindingContext).TermId = term.TermId;
    }

    public async Task UpdateCourse(Term term)
    {
        InitializeComponent();
        BindingContext = new CourseView();
        var conn = new Connection();
        var db = conn.GetAsyncConnection();
        await db.UpdateAsync(somecourse());
        ((CourseView)BindingContext).TermId = term.TermId;
    }

    public async Task DeleteCourse(Term term)
    {
        InitializeComponent();
        BindingContext = new CourseView();
        var conn = new Connection();
        var db = conn.GetAsyncConnection();
        await db.DeleteAsync(somecourse());
        ((CourseView)BindingContext).TermId = term.TermId;
    }

    private async Task AddCourse_OnButtonClicked(object sender, EventArgs e)
    {
        AddCourse(selectedTerm);
        await Navigation.PopAsync();
    }


}
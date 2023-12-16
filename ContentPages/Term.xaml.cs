using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseTracker.Models;
using CourseTracker.Supplemental;
using CourseTracker.ViewModels;

namespace CourseTracker.ContentPages;

public partial class Term : ContentPage
{
    private Connection _conn;
    private Models.Course _course;
    private Models.Term _term;

    public Term()
    {
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
        ((TermView) BindingContext).TermId = course.TermId;
    }

    public async Task UpdateTerm(Models.Course course)
    {
        InitializeComponent();
        BindingContext = new TermView();
        var db = _conn.GetAsyncConnection();
        await db.UpdateAsync(_term); //TODO: BUILD CONSTRUCTOR FROM INPUTS
        ((TermView) BindingContext).TermId = course.TermId;
    }

    public async Task DeleteTerm(Models.Course course)
    {
        InitializeComponent();
        BindingContext = new TermView();
        var db = _conn.GetAsyncConnection();
        await db.DeleteAsync(_term); //TODO: BUILD CONSTRUCTOR FROM INPUTS
        ((TermView) BindingContext).TermId = course.TermId;
    }

    private async Task AddTerm_OnButtonClicked(object sender, EventArgs e)
    {
        _ = AddTerm(_course); //TODO: Make sure this can actually bind to a course
        await Navigation.PopAsync();
    }

    private async Task UpdateTerm_OnButtonClicked(object sender, EventArgs e)
    {
        _ = UpdateTerm(_course); //TODO: Make sure this can actually bind to a course
        await Navigation.PopAsync();
    }

    private async Task DeleteTerm_OnButtonClicked(object sender, EventArgs e)
    {
        _ = DeleteTerm(_course); //TODO: Make sure this can actually bind to a course
        await Navigation.PopAsync();
    }
}
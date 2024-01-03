using CourseTracker.Supplemental;

namespace CourseTracker.ContentPages.TermContents;

public partial class TermCreateModify
{
    private TrackerDb _db;

    public TermCreateModify(TrackerDb db)
    {
        InitializeComponent();
        _db = db;
    }

    async void Save_OnClicked(object sender, EventArgs e)
    {
        if (TermStart.Date < TermStart.MinimumDate || TermEnd.Date > TermEnd.MaximumDate)
        {
            await DisplayAlert("Invalid Date", "Please select a valid date", "OK");
            return;
        }

        //TODO: finish
    }

    async Task Cancel_OnClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}
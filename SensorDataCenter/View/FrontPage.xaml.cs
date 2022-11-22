using SensorDataCenter.ViewModel;

namespace SensorDataCenter.View;

public partial class FrontPage : ContentPage
{
	public FrontPage(FrontPageViewModel frontPageViewModel)
	{
		InitializeComponent();
        BindingContext = frontPageViewModel;
    }
}
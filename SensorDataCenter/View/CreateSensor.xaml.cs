using SensorDataCenter.ViewModel;

namespace SensorDataCenter.View;

public partial class CreateSensor : ContentPage
{
	public CreateSensor(CreateSensorViewModel createSensorViewModel)
	{
		InitializeComponent();
		BindingContext = createSensorViewModel;
	}
}
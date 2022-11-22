using System;

namespace SensorDataCenter.View;

public partial class PostSoundPage : ContentPage
{
	public PostSoundPage(PostSoundPage postSoundPage)
	{
		InitializeComponent();
		BindingContext = postSoundPage;
	}
}
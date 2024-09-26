using SmartHouse_MAU.ViewModel;

namespace SmartHouse_MAUI;

public partial class MainPage : ContentPage
{

    HouseViewModel houseViewModel;
    public MainPage()
	{

      InitializeComponent();
//        houseViewModel = new HouseViewModel() { Temperature = -44 };
        houseViewModel = new HouseViewModel() ;// start temp = 20

        houseViewModel.OuterTemperature = 20;
        this.BindingContext = houseViewModel;
    }
    private void BtnMonitor_Clicked(object sender, EventArgs e)
    {
        if (houseViewModel.OnLamp)
        {
            LblLamp.BackgroundColor = Colors.Yellow;
            //LblLamp.TextColor = (Color)Resources["Gray600"]; 
            LblLamp.TextColor = Color.FromRgb(20,20,20);
        }
        else {
            LblLamp.BackgroundColor = Colors.Gray;
            LblLamp.TextColor =  Colors.White;
        }
    
    }
	
}


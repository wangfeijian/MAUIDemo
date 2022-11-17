using FirstMauiForMvvm.ViewModels;

namespace FirstMauiForMvvm;

public class ServiceLocator
{
    private IServiceProvider _serviceProvider;

    public MainPageViewModel MainPageViewModel => _serviceProvider.GetService<MainPageViewModel>();

    public ServiceLocator()
	{
		var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<MainPageViewModel>();

        _serviceProvider = serviceCollection.BuildServiceProvider();
	}
}

using System.ComponentModel;
using System.Runtime.CompilerServices;
using Mobile3.Context;
using Mobile3.Models;

namespace Mobile3.ViewModels;

public class ViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private IEnumerable<User> _users; // Приватную переменную _users (для внутренних преобразований).

    public IEnumerable<User> users // Публичную переменную users (для внешних преобразований).
    {
        get { return _users; }
        set
        {
            _users = value;
            OnPropertyChanged();
        } // Присваиваем внутренней переменной значение и вызываем ивент.
    }

    private void GetUser() // Присваиваем внешней переменной значение и преобразуем ее в лист.
    {
        using (var context = new Pr4SpContext())
        {
            users = context.Users.ToList();
        }
    }

    private IEnumerable<Transport> _transports; // Приватную переменную _Transports (для внутренних преобразований).

    public IEnumerable<Transport> transports // Публичную переменную Transports (для внешних преобразований).
    {
        get { return _transports; }
        set
        {
            _transports = value;
            OnPropertyChanged();
        } // Присваиваем внутренней переменной значение и вызываем ивент.
    }

    private void GetTransport() // Присваиваем внешней переменной значение и преобразуем ее в лист.
    {
        using (var context = new Pr4SpContext())
        {
            transports = context.Transports.ToList();
        }
    }

    public ViewModel() // Вызываем наши функции. 
    {
        newUser = new User();
        newTransport = new Transport();
        GetUser();
        GetTransport();
    }

    private User _newUser;

    public User newUser
    {
        get { return _newUser; }
        set { _newUser = value; OnPropertyChanged(); } 
    }
    
    public DelegateCommand AddUserCommand 
    {
        get
        {
            return new DelegateCommand(o =>
            {
                AddUser();
            });
        }
    }
    
    private void AddUser() 
    {
        using(var context = new Pr4SpContext())
        {
            context.Users.Add(newUser);
            context.SaveChanges();
            users = context.Users.ToList();
        }
        newUser = new User(); 
    }
    
    private Transport _newTransport; 
    public Transport newTransport 
    {
        get { return _newTransport; }
        set { _newTransport = value; OnPropertyChanged(); }
    }

    public DelegateCommand AddTransportCommand 
    {
        get
        {
            return new DelegateCommand(o =>
            {
                AddTransport();
            });
        }
    }

    private void AddTransport() 
    {
        using (var context = new Pr4SpContext())
        {
            context.Transports.Add(newTransport);
            context.SaveChanges();
            transports = context.Transports.ToList();
        }
        newTransport = new Transport();
    }
}






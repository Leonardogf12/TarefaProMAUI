using Plugin.Firebase.CloudMessaging;
using System.Globalization;
using TarefaPro.MAUI.MVVM.Models;
using TarefaPro.MAUI.Repositories.Tasks;
using TarefaPro.MAUI.Services.Firebase;

namespace TarefaPro.MAUI.MVVM.ViewModels.Tasks
{
    [QueryProperty(nameof(CategorySelectedToTask), "CategorySelectedToTask")]
    public class AddTaskViewModel : BaseViewModel
    {
        private readonly TaskRepository _taskRepository;

        private readonly INotificationFirebaseService _notificationFirebaseService;

        #region Properts

        private CategoryModel _categorySelectedToTask;
        public CategoryModel CategorySelectedToTask
        {
            get => _categorySelectedToTask;
            set => SetProperty(ref _categorySelectedToTask, value);
        }


        private bool _isEnabledReminder = false;
        public bool IsEnabledReminder
        {
            get => _isEnabledReminder;
            set
            {
                SetProperty(ref _isEnabledReminder, value);

                if (value)
                {
                    BackgroundIsEnabled = (Style)App.Current.Resources["borderFormRemindeEnabled"];
                }
                else
                {
                    BackgroundIsEnabled = (Style)App.Current.Resources["borderFormRemindeDisabled"];
                }

            }
        }


        private Style _backgroundIsEnabled = (Style)App.Current.Resources["borderFormRemindeDisabled"];
        public Style BackgroundIsEnabled
        {
            get => _backgroundIsEnabled;
            set => SetProperty(ref _backgroundIsEnabled, value);
        }


        private string _taskName;
        public string TaskName
        {
            get => _taskName;
            set => SetProperty(ref _taskName, value);
        }


        private string _taskDescription;
        public string TaskDescription
        {
            get => _taskDescription;
            set => SetProperty(ref _taskDescription, value);
        }


        private DateTime _dateEvent = DateTime.Now;
        public DateTime DateEvent
        {
            get => _dateEvent;
            set => SetProperty(ref _dateEvent, value);
        }


        private DateTime _minDateEvent = DateTime.Now.AddYears(-1);
        public DateTime MinDateEvent
        {
            get => _minDateEvent;
            set => SetProperty(ref _minDateEvent, value);
        }


        private DateTime _maxDateEvent = DateTime.Now.AddYears(5);
        public DateTime MaxDateEvent
        {
            get => _maxDateEvent;
            set => SetProperty(ref _maxDateEvent, value);
        }


        private DateTime _dateReminde = DateTime.Now;
        public DateTime DateReminde
        {
            get => _dateReminde;
            set => SetProperty(ref _dateReminde, value);
        }


        private DateTime _minDateReminde = DateTime.Now.AddYears(-1);
        public DateTime MinDateReminde
        {
            get => _minDateReminde;
            set => SetProperty(ref _minDateReminde, value);
        }


        private DateTime _maxDateReminde = DateTime.Now.AddYears(5);
        public DateTime MaxDateReminde
        {
            get => _maxDateReminde;
            set => SetProperty(ref _maxDateReminde, value);
        }


        private TimeSpan _hourReminde;
        public TimeSpan HourReminde
        {
            get => _hourReminde;
            set => SetProperty(ref _hourReminde, value);
        }


        #endregion

        public AddTaskViewModel(INotificationFirebaseService notificationFirebaseService)
        {
            _notificationFirebaseService = notificationFirebaseService;
            _taskRepository = new TaskRepository();
        }

        public async Task AddTask()
        {
            IsBusy = true;

            try
            {
                var newTask = new TaskModel();
                newTask.Name = TaskName;
                newTask.Description = TaskDescription;
                newTask.Color = CategorySelectedToTask.Color;
                newTask.CategoryId = CategorySelectedToTask.Id;
                newTask.DateEvent = DateEvent;
                newTask.IsReminder = IsEnabledReminder;
                newTask.DateTask = IsEnabledReminder ? DateReminde : DateTime.Now;
                newTask.HourTask = IsEnabledReminder ? HourReminde : new TimeSpan();

                var exist = await CheckIfExistTask(newTask.Name);

                if (exist)
                {
                    await App.Current.MainPage.DisplayAlert("Ops", "Já existe uma Tarefa com este nome. Favor verificar.", "OK");
                    return;
                }

                var result = await _taskRepository.SaveAsync(newTask);

                if (result > 0)
                {
                    if (IsEnabledReminder)
                        await PostNotification(newTask);

                    await App.Current.MainPage.DisplayAlert("Tarefa", "Tarefa salva com sucesso.", "OK");                   
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await App.Current.MainPage.DisplayAlert("Tarefa", "Ocorreu um erro durante o registro da Tarefa.", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task<bool> CheckIfExistTask(string name)
        {
            var result = await _taskRepository.GetTaskWithNameExistentAsync(name);

            return result == null ? false : true;
        }        

        private async Task PostNotification(TaskModel model)
        {
            await CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();
            var token = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();

            NotificationDto dto = new NotificationDto
            {
                Title = "Alerta de Compromisso",
                Description = $"{model.Name}: {model.Description}",
                UrlImage = "https://www.pushengage.com/wp-content/uploads/2022/10/How-to-Add-a-Push-Notification-Icon.png",
                DateTimeOfNotification = SetAndConvertDateTimeToUtcTimezone(model),
                Token = token
            };

            var result = await _notificationFirebaseService.PostNotificationAsync(dto, token);

            if (!result)
            {
                await App.Current.MainPage.DisplayAlert("Ops", "Ocorreu um erro inesperado ao salvar a notificação automática do lembrete." +
                    " Mas esta tudo bem, a tarefa continua salva.", "Ok");
                return;
            }
        }

        private DateTime SetAndConvertDateTimeToUtcTimezone(TaskModel model)
        {         
            DateTime dtlocal = model.DateTask.Date + model.HourTask;
          
            return TimeZoneInfo.ConvertTimeToUtc(dtlocal);        
        }
    }
}

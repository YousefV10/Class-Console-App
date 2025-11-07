using IDK;


var notifier = new Notifier();

var emailService = new EmailService();
var smsService = new SMSService();
var pushService = new PushNotificationService();


notifier.NotificationSent += emailService.SendEmail;
notifier.NotificationSent += smsService.SendSMS;
notifier.NotificationSent += pushService.SendPush;

Console.Write("Please sent a message ");
string message1 = Console.ReadLine();

notifier.SendNotification(message1);




notifier.NotificationSent -= smsService.SendSMS;


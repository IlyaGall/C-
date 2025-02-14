using System;
using Decorator.Problem;
using Facade.Solution;
using Facade.Solution.Dto;
using YouTubeLibrary;
using NotificationOptions = Decorator.Solution.NotificationOptions;

namespace StructuralPatterns
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
            
            #region Adapter

            var cardInfo = new Adapter.Solution.CardInfo()
            {
                Id = Guid.NewGuid(),
                StartDate = DateTime.UtcNow
            };
            var cardManager = new Adapter.Solution.CardManager();
            cardManager.Issue(cardInfo);

            #endregion
            */

/*
            #region Decorator
            
            var notificationOptions = new NotificationOptions()
            {
                SendToEmail = true,
                SendToSms = false,
                SendFBNotification = true
            };
            var decoratorCardManager = new Decorator.Solution.CardManager(notificationOptions);
            decoratorCardManager.Issue();

            //FileDecorator.Write();
            //FileDecorator.WriteArchived();
            
            #endregion
*/           
            
            /*
            #region Proxy

            var youTubeThirdPartyManager = new YouTubeThirdPartyManager();
            var youTubeThirdPartyManagerCached =
                new Proxy.Solution.YouTubeThirdPartyManagerCached(youTubeThirdPartyManager);
            var youTubeManager = new Proxy.Solution.YouTubeManager(youTubeThirdPartyManagerCached);
            youTubeManager.RenderVideoPage(1);
            youTubeManager.RenderVideoPage(1);

            #endregion
            */
            
            /*
            #region Facade

            var printFormDataService = new PrintFormDataService();
            var printFormTemplateService = new PrintFormTemplateService();
            var printFormGenerator = new PrintFormGenerator();
            var printService = new PrintFormService(printFormDataService, printFormTemplateService, printFormGenerator);
            var decoratorCardManager = new Facade.Solution.DocumentService(printService);
            var documentDto = new Facade.Solution.Dto.DocumentDto();
            var printForm = decoratorCardManager.GeneratePrintForm(documentDto);

            #endregion
            */

/*            
            #region Bridge

            var device = new Bridge.Solution.Tv();
            var remote = new Bridge.Solution.Remote(device);
            remote.TogglePower();

            #endregion
  */        

/*
            #region Flyweight

            var forest = new Flyweight.Solution.ForestContext();
            forest.PlantTree(1, 3, 100, 303);
            forest.PlantTree(5, 4, 10, 30);
            forest.PlantTree(1, 3, 101, 304);
            forest.Draw();

            #endregion
*/          
/*
            #region Composite

            var pie = new Composite.Solution.Pie(10);
            var container = new Composite.Solution.Container(1);
            container.AddProduct(pie);
            var price = container.GetPrice();

            #endregion
            */
        }
    }
}
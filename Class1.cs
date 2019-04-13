using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using NRECA.DemographicService;
using DemographicServiceTestConsoleApp.ServiceRef;
using AutoMapper;
using NRECA.BizTalk.NNS.Flex.WEX.TLS12.EndPointBehavior;
using System.Security.Cryptography.X509Certificates;
//using ManagementServiceClientWrapper = ServiceClientWrapper<DemographicServiceTestConsoleApp.ServiceRef.DemographicServiceClient, DemographicServiceTestConsoleApp.ServiceRef.DemographicService>;

namespace ClassLibrary2
{
    public class WEXServiceClientWrapperTest
    {
        static void Main(string[] args)
        {

            TestGetConsumer();


            WSHttpBinding binding = new WSHttpBinding();
            binding.Name = "DemographicService";
            binding.Security = new WSHttpSecurity();
            binding.Security.Mode = SecurityMode.TransportWithMessageCredential;
            binding.Security.Transport = new HttpTransportSecurity();
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.None;
            binding.Security.Message = new NonDualMessageSecurityOverHttp();

            //Set the ClientCredential property to use certificate authentication type
            binding.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;
            binding.Security.Message.NegotiateServiceCredential = false;
            binding.Security.Message.EstablishSecurityContext = false;

            EndpointAddress endpoint = new EndpointAddress(new Uri("https://staginghixservice.lh1ondemand.com/v2_0/Demographic.svc"));

            WebConfiguration config = new WebConfiguration(endpoint, binding);

            DemographicServiceTestConsoleApp.ServiceRef.DemographicServiceClient client = new DemographicServiceTestConsoleApp.ServiceRef.DemographicServiceClient(binding, endpoint);

            client.Endpoint.EndpointBehaviors.Add(new Wex1CloudEndpointBehavior("TLS12"));

            //Both the client and the service are authenticated with certificates
            //Setting the X.509 certificate that the client uses to authenticate against the service
            client.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindBySubjectName, "biztalk.nreca.org");

            //Specifiy the certificate to be used when authenticating a service to the client
            client.ClientCredentials.ServiceCertificate.SetDefaultCertificate(StoreLocation.LocalMachine, StoreName.TrustedPeople, X509FindType.FindBySubjectName, "allsvc.lh1ondemand.com");


            DemographicServiceTestConsoleApp.ServiceRef.AddConsumerRequest addRequest = new DemographicServiceTestConsoleApp.ServiceRef.AddConsumerRequest();

            DemographicServiceTestConsoleApp.ServiceRef.ChangeConsumerRequest chgRequest = new DemographicServiceTestConsoleApp.ServiceRef.ChangeConsumerRequest();

            DemographicServiceTestConsoleApp.ServiceRef.ConsumerRequest getRequest = new DemographicServiceTestConsoleApp.ServiceRef.ConsumerRequest();

            getRequest.ConsumerKey = new DemographicServiceTestConsoleApp.ServiceRef.ConsumerKey();
            getRequest.ConsumerKey.ConsumerIdentifier = "001806804";
            getRequest.ConsumerKey.EmployerCode = "16093";
            getRequest.ConsumerKey.AdministratorAlias = "NRC";

            getRequest.MessageId = "190207563";

            NRECA.DemographicService.ChangeConsumerRequest chgcanonicalRequest = new NRECA.DemographicService.ChangeConsumerRequest();
            chgcanonicalRequest.ConsumerDemographicInformation = new NRECA.DemographicService.Consumer();
            chgcanonicalRequest.ConsumerDemographicInformation.ClassEffectiveDate = DateTime.Parse("2019-02-05");
            chgcanonicalRequest.ConsumerDemographicInformation.ClassName = "All";
            chgcanonicalRequest.ConsumerDemographicInformation.DateOfBirth = DateTime.Parse("1981-01-15");
            chgcanonicalRequest.ConsumerDemographicInformation.DateOfHire = DateTime.Parse("2019-02-05");
            chgcanonicalRequest.ConsumerDemographicInformation.Division = "unassigned";
            chgcanonicalRequest.ConsumerDemographicInformation.EmployeeNumber = "001806804";
            chgcanonicalRequest.ConsumerDemographicInformation.EmployerEmployeeId = "0018068040116093001";
            chgcanonicalRequest.ConsumerDemographicInformation.EmploymentStatus = NRECA.DemographicService.EmploymentStatusValues.Active;
            chgcanonicalRequest.ConsumerDemographicInformation.EmploymentStatusEffectiveDate = DateTime.Parse("2019-02-05");
            chgcanonicalRequest.ConsumerDemographicInformation.FirstName = "Daniel";
            chgcanonicalRequest.ConsumerDemographicInformation.Gender = NRECA.DemographicService.GenderTypeValues.Male;
            chgcanonicalRequest.ConsumerDemographicInformation.FirstName = "Daniel";
            chgcanonicalRequest.ConsumerDemographicInformation.LastName = "Adams";
            chgcanonicalRequest.ConsumerDemographicInformation.Password = "One1pa@rd190207563";
            chgcanonicalRequest.ConsumerDemographicInformation.PayrollFrequency = "Select a Payroll";
            chgcanonicalRequest.ConsumerDemographicInformation.PayrollFrequencyEffectiveDate = DateTime.Parse("2019-02-05");
            chgcanonicalRequest.ConsumerDemographicInformation.SocialSecurityNumber = "479827553";
            chgcanonicalRequest.ConsumerDemographicInformation.UserName = "tempuser190207563";

            chgcanonicalRequest.ConsumerDemographicInformation.HomeAddress = new NRECA.DemographicService.Address();
            chgcanonicalRequest.ConsumerDemographicInformation.HomeAddress.AddressLine1 = "3032 Harrison Rd";
            chgcanonicalRequest.ConsumerDemographicInformation.HomeAddress.City = "Ames";
            chgcanonicalRequest.ConsumerDemographicInformation.HomeAddress.State = "IA";
            chgcanonicalRequest.ConsumerDemographicInformation.HomeAddress.ZipCode = "50010";

            chgcanonicalRequest.ConsumerDemographicInformation.HomePhone = new NRECA.DemographicService.PhoneNumber();
            chgcanonicalRequest.ConsumerDemographicInformation.HomePhone.AreaCode = "515";
            chgcanonicalRequest.ConsumerDemographicInformation.HomePhone.PhoneNumberMember = "988-3908";

            chgcanonicalRequest.ConsumerKey = new NRECA.DemographicService.ConsumerKey();
            chgcanonicalRequest.ConsumerKey.ConsumerIdentifier = "001806804";
            chgcanonicalRequest.ConsumerKey.EmployerCode = "16093";
            chgcanonicalRequest.ConsumerKey.AdministratorAlias = "NRC";

            chgcanonicalRequest.MessageId = "190207563";

            //NRECA.DemographicService.AddConsumer addcanonicalRequest = new AddConsumer();
            //addcanonicalRequest.consumerRequest = new NRECA.DemographicService.AddConsumerRequest();
            //addcanonicalRequest.consumerRequest.ConsumerDemographicInformation = new NRECA.DemographicService.Consumer();
            //addcanonicalRequest.consumerRequest.ConsumerDemographicInformation.ClassEffectiveDate = DateTime.Parse("2019-02-05");
            //addcanonicalRequest.consumerRequest.ConsumerDemographicInformation.ClassName = "All";
            //addcanonicalRequest.consumerRequest.ConsumerDemographicInformation.DateOfBirth = DateTime.Parse("1981-01-15");
            //addcanonicalRequest.consumerRequest.ConsumerDemographicInformation.DateOfHire = DateTime.Parse("2019-02-05");
            //addcanonicalRequest.consumerRequest.ConsumerDemographicInformation.Division = "unassigned";
            //addcanonicalRequest.consumerRequest.ConsumerDemographicInformation.EmployeeNumber = "001806804";
            //addcanonicalRequest.consumerRequest.ConsumerDemographicInformation.EmployerEmployeeId = "0018068040116093001";
            //addcanonicalRequest.consumerRequest.ConsumerDemographicInformation.EmploymentStatus = NRECA.DemographicService.EmploymentStatusValues.Active;
            //addcanonicalRequest.consumerRequest.ConsumerDemographicInformation.EmploymentStatusEffectiveDate = DateTime.Parse("2019-02-05");
            //addcanonicalRequest.consumerRequest.ConsumerDemographicInformation.FirstName = "Daniel";
            //addcanonicalRequest.consumerRequest.ConsumerDemographicInformation.Gender = NRECA.DemographicService.GenderTypeValues.Male;
            //addcanonicalRequest.consumerRequest.ConsumerDemographicInformation.LastName = "Adams";
            //addcanonicalRequest.consumerRequest.ConsumerDemographicInformation.Password = "One1pa@rd190207563";
            //addcanonicalRequest.consumerRequest.ConsumerDemographicInformation.PayrollFrequency = "Select a Payroll";
            //addcanonicalRequest.consumerRequest.ConsumerDemographicInformation.PayrollFrequencyEffectiveDate = DateTime.Parse("2019-02-05");
            //addcanonicalRequest.consumerRequest.ConsumerDemographicInformation.SocialSecurityNumber = "479827553";
            //addcanonicalRequest.consumerRequest.ConsumerDemographicInformation.UserName = "tempuser190207563";

            //addcanonicalRequest.consumerRequest.ConsumerDemographicInformation.HomeAddress = new NRECA.DemographicService.Address();
            //addcanonicalRequest.consumerRequest.ConsumerDemographicInformation.HomeAddress.AddressLine1 = "3032 Harrison Rd";
            //addcanonicalRequest.consumerRequest.ConsumerDemographicInformation.HomeAddress.City = "Ames";
            //addcanonicalRequest.consumerRequest.ConsumerDemographicInformation.HomeAddress.State = "IA";
            //addcanonicalRequest.consumerRequest.ConsumerDemographicInformation.HomeAddress.ZipCode = "50010";

            //addcanonicalRequest.consumerRequest.ConsumerDemographicInformation.HomePhone = new NRECA.DemographicService.PhoneNumber();
            //addcanonicalRequest.consumerRequest.ConsumerDemographicInformation.HomePhone.AreaCode = "515";
            //addcanonicalRequest.consumerRequest.ConsumerDemographicInformation.HomePhone.PhoneNumberMember = "988-3908";

            //addcanonicalRequest.consumerRequest.ConsumerKey = new NRECA.DemographicService.ConsumerKey();
            //addcanonicalRequest.consumerRequest.ConsumerKey.ConsumerIdentifier = "001806804";
            //addcanonicalRequest.consumerRequest.ConsumerKey.EmployerCode = "16093";
            //addcanonicalRequest.consumerRequest.ConsumerKey.AdministratorAlias = "NRC";

            //addcanonicalRequest.consumerRequest.MessageId = "190207563";


            //Mapper.Initialize(cfg => {
            //cfg.CreateMap<NRECA.DemographicService.AddConsumerRequest, DemographicServiceTestConsoleApp.ServiceRef.AddConsumerRequest>().DisableCtorValidation();
            //cfg.CreateMap<NRECA.DemographicService.Consumer, DemographicServiceTestConsoleApp.ServiceRef.Consumer>().DisableCtorValidation();
            //cfg.CreateMap<NRECA.DemographicService.ConsumerKey, DemographicServiceTestConsoleApp.ServiceRef.ConsumerKey>().DisableCtorValidation();
            //);

            //var Output = Mapper.Map<DemographicServiceTestConsoleApp.ServiceRef.AddConsumerRequest>(addcanonicalRequest.consumerRequest);
            //var config1 = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<NRECA.DemographicService.AddConsumerRequest, DemographicServiceTestConsoleApp.ServiceRef.AddConsumerRequest>().DisableCtorValidation().ForMember(destination => destination.ConsumerDemographicInformation, opts => opts.MapFrom(source => source.ConsumerDemographicInformation));
            //    cfg.CreateMap< NRECA.DemographicService.Consumer, DemographicServiceTestConsoleApp.ServiceRef.Consumer>().DisableCtorValidation();
            //    cfg.CreateMap<NRECA.DemographicService.ConsumerKey, DemographicServiceTestConsoleApp.ServiceRef.ConsumerKey>().DisableCtorValidation();
            //});


            var config1 = new MapperConfiguration(cfg => {
                cfg.CreateMap
                <NRECA.DemographicService.Address, DemographicServiceTestConsoleApp.ServiceRef.Address>()
                .ForMember(destination => destination.ExtensionData, opts => opts.Ignore());
                
            });


            var config2 = new MapperConfiguration(cfg => {
                cfg.CreateMap
                <NRECA.DemographicService.Consumer, DemographicServiceTestConsoleApp.ServiceRef.Consumer>()
                .ForMember(destination => destination.ExtensionData, opts => opts.Ignore())
                .ForMember(destination => destination.HomeAddress, opts => opts.Ignore())
                .ForMember(destination => destination.HomePhone, opts => opts.Ignore())
                ;

            });

            var config3 = new MapperConfiguration(cfg => {
                cfg.CreateMap
                <NRECA.DemographicService.ConsumerKey, DemographicServiceTestConsoleApp.ServiceRef.ConsumerKey>()
                .ForMember(destination => destination.ExtensionData, opts => opts.Ignore())
                ;

            });

            var config4 = new MapperConfiguration(cfg => {
                cfg.CreateMap
                <NRECA.DemographicService.PhoneNumber, DemographicServiceTestConsoleApp.ServiceRef.PhoneNumber>()
                .ForMember(destination => destination.ExtensionData, opts => opts.Ignore());

            });

            config1.AssertConfigurationIsValid();
            config2.AssertConfigurationIsValid();
            config3.AssertConfigurationIsValid();
            config4.AssertConfigurationIsValid();

            var mapper1 = config1.CreateMapper();
            var mapper2 = config2.CreateMapper();
            var mapper3 = config3.CreateMapper();
            var mapper4 = config4.CreateMapper();

    
            DemographicServiceTestConsoleApp.ServiceRef.Address caddr = mapper1.Map<DemographicServiceTestConsoleApp.ServiceRef.Address>(chgcanonicalRequest.ConsumerDemographicInformation.HomeAddress);

            DemographicServiceTestConsoleApp.ServiceRef.Consumer consumer = mapper2.Map<DemographicServiceTestConsoleApp.ServiceRef.Consumer>(chgcanonicalRequest.ConsumerDemographicInformation);

            DemographicServiceTestConsoleApp.ServiceRef.ConsumerKey ckey = mapper3.Map<DemographicServiceTestConsoleApp.ServiceRef.ConsumerKey>(chgcanonicalRequest.ConsumerKey);

            DemographicServiceTestConsoleApp.ServiceRef.PhoneNumber cph = mapper4.Map<DemographicServiceTestConsoleApp.ServiceRef.PhoneNumber>(chgcanonicalRequest.ConsumerDemographicInformation.HomePhone);

            chgRequest.ConsumerDemographicInformation = consumer;
            chgRequest.ConsumerDemographicInformation.HomeAddress = caddr;
            chgRequest.ConsumerDemographicInformation.HomePhone = cph;
            chgRequest.ConsumerKey = ckey;

            DemographicServiceTestConsoleApp.ServiceRef.GetConsumerResponse getresp = client.GetConsumer(getRequest);


            NRECA.DemographicService.GetConsumerResponse1 resp1 = new GetConsumerResponse1();
            resp1.GetConsumerResult = new NRECA.DemographicService.GetConsumerResponse();

            resp1.GetConsumerResult.ConsumerInformation = new NRECA.DemographicService.Consumer();

            resp1.GetConsumerResult.OperationResult = new NRECA.DemographicService.OperationResult();
            resp1.GetConsumerResult.OperationResult.ExecutionMessages = new NRECA.DemographicService.ExecutionMessage[getresp.OperationResult.ExecutionMessages.Length];
            resp1.GetConsumerResult.OperationResult.ExecutionMessages[0] = new NRECA.DemographicService.ExecutionMessage();
            resp1.GetConsumerResult.OperationResult.ExecutionMessages[0].Code = getresp.OperationResult.ExecutionMessages[0].Code;
            resp1.GetConsumerResult.OperationResult.ExecutionMessages[0].Description = getresp.OperationResult.ExecutionMessages[0].Description;
            resp1.GetConsumerResult.OperationResult.ExecutionMessages[0].NotificationType = (NRECA.DemographicService.ExecutionNotificationValues)getresp.OperationResult.ExecutionMessages[0].NotificationType;
            resp1.GetConsumerResult.MessageId = getresp.MessageId;
            resp1.GetConsumerResult.OperationResult.OperationSucceeded = getresp.OperationResult.OperationSucceeded;



            var config5 = new MapperConfiguration(cfg => {
                cfg.CreateMap
                <DemographicServiceTestConsoleApp.ServiceRef.Consumer, NRECA.DemographicService.Consumer>()
                .ForMember(destination => destination.HomeAddress, opts => opts.Ignore())
                .ForMember(destination => destination.HomePhone, opts => opts.Ignore())
                ;               
            });

            var config6 = new MapperConfiguration(cfg => {
                cfg.CreateMap
                <NRECA.DemographicService.Address, DemographicServiceTestConsoleApp.ServiceRef.Address>()
                .ForMember(destination => destination.ExtensionData, opts => opts.Ignore());

            });

            var config7 = new MapperConfiguration(cfg => {
                cfg.CreateMap
                <NRECA.DemographicService.PhoneNumber, DemographicServiceTestConsoleApp.ServiceRef.PhoneNumber>()
                .ForMember(destination => destination.ExtensionData, opts => opts.Ignore());

            });

            config5.AssertConfigurationIsValid();
            config6.AssertConfigurationIsValid();
            config7.AssertConfigurationIsValid();

            var mapper5 = config5.CreateMapper();
            var mapper6 = config6.CreateMapper();
            var mapper7 = config7.CreateMapper();

            NRECA.DemographicService.Consumer csr = mapper6.Map<NRECA.DemographicService.Consumer>(getresp.ConsumerInformation);
            NRECA.DemographicService.Address gaddr = mapper1.Map<NRECA.DemographicService.Address>(getresp.ConsumerInformation.HomeAddress);
            NRECA.DemographicService.PhoneNumber gph = mapper4.Map<NRECA.DemographicService.PhoneNumber>(getresp.ConsumerInformation.HomePhone);

          
            resp1.GetConsumerResult.ConsumerInformation = csr;
            resp1.GetConsumerResult.ConsumerInformation.HomePhone = gph;
            resp1.GetConsumerResult.ConsumerInformation.HomeAddress = gaddr;
           //resp1.AddConsumerResult.OperationResult = cresp6;

            //Console.WriteLine(resp.OperationResult.ExecutionMessages[0].Description);
            Console.ReadKey();
        }


        static void TestGetConsumer()
        {

            NRECA.DemographicService.GetConsumer getRequest = new NRECA.DemographicService.GetConsumer();
            getRequest.consumerRequest = new NRECA.DemographicService.ConsumerRequest();
            getRequest.consumerRequest.ConsumerKey = new NRECA.DemographicService.ConsumerKey();
            getRequest.consumerRequest.ConsumerKey.ConsumerIdentifier = "001806804";
            getRequest.consumerRequest.ConsumerKey.EmployerCode = "16093";
            getRequest.consumerRequest.ConsumerKey.AdministratorAlias = "NRC";

            getRequest.consumerRequest.MessageId = "190207563";

            EndpointAddress endpoint = new EndpointAddress(new Uri("https://staginghixservice.lh1ondemand.com/v2_0/Demographic.svc"));

            NRECA.DemographicService.DemographicServiceClient testclient = new NRECA.DemographicService.DemographicServiceClient(endpoint);
            testclient.InvokeGetConsumer(getRequest);

        }
    }

}

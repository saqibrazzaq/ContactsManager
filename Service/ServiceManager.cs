using AutoMapper;
using Contracts;
using Entities.ConfigurationModels;
using Entities.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Repository.Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IPersonService> _personService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public ServiceManager(IRepositoryManager repositoryManager,
            ILoggerManager logger,
            IMapper mapper,
            UserManager<User> userManager,
            IOptions<JwtConfiguration> configuration
            )
        {
            _personService = new Lazy<IPersonService>(() =>
                new PersonService(repositoryManager, logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() =>
                new AuthenticationService(logger, mapper, userManager, configuration));
        }
        public IPersonService PersonService => _personService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}

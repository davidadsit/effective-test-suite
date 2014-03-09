using System;
using AutoMapper;

namespace IntegrationTests.Verify3rdPartyTests
{
    public class UserMapper
    {
        public UserMapper()
        {
            Mapper.CreateMap<User, UserViewModel>()
                .ForMember(uservm => uservm.FullName, map => map.MapFrom(user => user.FirstName + " " + user.LastName))
                .ForMember(uservm => uservm.MemberhipAgeInDays, map => map.MapFrom(user => (DateTime.Now - user.JoinDate).TotalDays));
        }

        public UserViewModel ToViewModel(User user)
        {
            return Mapper.Map<User, UserViewModel>(user);
        }
    }
}
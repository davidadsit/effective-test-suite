using System;
using Machine.Specifications;

namespace IntegrationTests.Verify3rdPartyTests
{
    [Subject(typeof (UserMapper))]
    public class When_mapping_a_user_to_a_userviewmodel
    {
        Establish context = () =>
                                {
                                    userMapper = new UserMapper();
                                    user = new User()
                                               {
                                                   FirstName = "first",
                                                   LastName = "last",
                                                   JoinDate = DateTime.Now.AddDays(-expectedMembershipAgeInDays),
                                                   FavoriteColor = "green",
                                                   Region = "Eastern",
                                               };
                                };

        Because of = () => userViewModel = userMapper.ToViewModel(user);

        It should_set_the_full_name = () => userViewModel.FullName.ShouldEqual(user.FirstName + " " + user.LastName);
        It should_set_the_age = () => userViewModel.MemberhipAgeInDays.ShouldEqual(expectedMembershipAgeInDays);
        It should_set_the_favorite_color = () => userViewModel.FavoriteColor.ShouldEqual(user.FavoriteColor);
        It should_set_the_region = () => userViewModel.Region.ShouldEqual(user.Region);

        static UserMapper userMapper;
        static User user;
        static UserViewModel userViewModel;
        static int expectedMembershipAgeInDays = 415;
    }
}
using System;
using bloggr_CS.Models;
using bloggr_CS.Repositories;

namespace bloggr_CS.Services
{
    public class ProfilesService
    {
        public readonly ProfilesRepository _repo;

        public ProfilesService(ProfilesRepository repo)
        {
            _repo = repo;
        }

        internal Profile GetOrCreateProfile(Profile userInfo)
        {
            Profile profile = _repo.GetById(userInfo.Id);
            if (profile == null)
            {
                return _repo.Create(userInfo);
            }
            return profile;
        }

        internal Profile GetProfileById(string id)
        {
            Profile profile = _repo.GetById(id);
            if (profile == null)
            {
                throw new Exception("Invalid Id");
            }
            return profile;
        }

    }
}
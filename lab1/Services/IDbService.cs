﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab1.Entities;

namespace lab1.Services;

public interface IDbService
{
    IEnumerable<Group> GetAllGroups();
    IEnumerable<Song> GetSongsByGroup(int id);
    void Init();
}

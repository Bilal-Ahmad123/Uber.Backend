﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber.Backend.Core;

  public interface INotificationService
  {
  Task NotifyAsync(string message);
  }

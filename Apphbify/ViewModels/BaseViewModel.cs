﻿using System;
using Nancy.Session;

namespace Apphbify.ViewModels
{
    public class BaseViewModel
    {
        public bool IsLoggedOn { get; set; }
        public string ErrorFlash { get; set; }
        public string SuccessFlash { get; set; }
        public string CurrentPage { get; set; }
        public bool HasErrorFlash { get { return !String.IsNullOrWhiteSpace(ErrorFlash); } }
        public bool HasSuccessFlash { get { return !String.IsNullOrWhiteSpace(SuccessFlash); } }

        public BaseViewModel(string pageName, ISession session)
        {
            CurrentPage = pageName;
            IsLoggedOn = session[SessionKeys.ACCESS_TOKEN] != null;
            ErrorFlash = session[SessionKeys.FLASH_ERROR] as string;
            SuccessFlash = session[SessionKeys.FLASH_SUCCESS] as string;
            session.Delete(SessionKeys.FLASH_ERROR);
            session.Delete(SessionKeys.FLASH_SUCCESS);
        }
    }
}
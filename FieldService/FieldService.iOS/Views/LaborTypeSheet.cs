//
//  Copyright 2012  Xamarin Inc.
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using FieldService.Data;
using FieldService.Utilities;

namespace FieldService.iOS
{
	/// <summary>
	/// Action sheet for selecting labor type
	/// </summary>
	public class LaborTypeSheet : UIActionSheet
	{
		readonly LaborType[] types;

		public LaborTypeSheet ()
		{
			types = (LaborType[])Enum.GetValues (typeof(LaborType));

			foreach (LaborType type in types) {
				AddButton (type.ToUserString ());
			}

			Dismissed += (sender, e) => {
				if (e.ButtonIndex != -1)
					Type = types[e.ButtonIndex];
			};
		}

		/// <summary>
		/// The type the user selected, or null if none
		/// </summary>
		public LaborType? Type
		{
			get; 
			private set;
		}
	}
}


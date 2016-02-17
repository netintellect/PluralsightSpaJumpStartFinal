﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.Diagrams.MindMap
{
	public class IconsCollection : ObservableCollection<IconItem>
	{
		public IconsCollection()
		{
			this.Add(new IconItem() { Path = "M16.000011,14.993016 L15.848616,15.060918 C14.491957,15.65391 12.856481,16.000164 11.096007,16.000164 C9.3355341,16.000164 7.7000594,15.65391 6.3434,15.060918 L6.1920128,14.99302 L6.197526,15.004113 C7.1086221,16.782713 8.9601431,18.000017 11.096011,18.000017 C13.23188,18.000017 15.083401,16.782713 15.994496,15.004113 z M7.5000019,6.0000095 C6.1192894,6.0000095 5.0000014,7.1192966 5.0000014,8.5000067 C5.0000014,9.8807173 6.1192894,11.000005 7.5000019,11.000005 C8.8807135,11.000005 10.000002,9.8807173 10.000002,8.5000067 C10.000002,7.1192966 8.8807135,6.0000095 7.5000019,6.0000095 z M14.500001,6.0000048 C13.119289,6.0000048 12.000001,7.1192918 12.000001,8.5000019 C12.000001,9.8807125 13.119289,11 14.500001,11 C15.880713,11 17,9.8807125 17,8.5000019 C17,7.1192918 15.880713,6.0000048 14.500001,6.0000048 z M11,0 C17.075132,0 22,4.9248676 22,11 C22,17.075132 17.075132,22 11,22 C4.9248676,22 0,17.075132 0,11 C0,4.9248676 4.9248676,0 11,0 z" });
			this.Add(new IconItem() { Path = "M6.9999976,15.000005 L6.9999976,17.000004 L14.999998,17.000004 L14.999998,15.000005 z M7.5000019,6.0000095 C6.1192894,6.0000095 5.0000014,7.1192966 5.0000014,8.5000067 C5.0000014,9.8807173 6.1192894,11.000005 7.5000019,11.000005 C8.8807135,11.000005 10.000002,9.8807173 10.000002,8.5000067 C10.000002,7.1192966 8.8807135,6.0000095 7.5000019,6.0000095 z M14.500001,6.0000048 C13.119289,6.0000048 12.000001,7.1192918 12.000001,8.5000019 C12.000001,9.8807125 13.119289,11 14.500001,11 C15.880713,11 17,9.8807125 17,8.5000019 C17,7.1192918 15.880713,6.0000048 14.500001,6.0000048 z M11,0 C17.075132,0 22,4.9248676 22,11 C22,17.075132 17.075132,22 11,22 C4.9248676,22 0,17.075132 0,11 C0,4.9248676 4.9248676,0 11,0 z" });
			this.Add(new IconItem() { Path = "M11.001041,14.334996 C8.9300604,14.334996 7.1531692,15.594007 6.3941593,17.388313 L6.3730431,17.439991 L6.5283489,17.359255 C7.8051038,16.712406 9.3442526,16.334702 11.001038,16.334702 C12.657822,16.334702 14.196971,16.712406 15.473726,17.359255 L15.629043,17.439997 L15.607924,17.388313 C14.848914,15.594007 13.072022,14.334996 11.001041,14.334996 z M7.5000019,6.0000095 C6.1192894,6.0000095 5.0000014,7.1192966 5.0000014,8.5000067 C5.0000014,9.8807173 6.1192894,11.000005 7.5000019,11.000005 C8.8807135,11.000005 10.000002,9.8807173 10.000002,8.5000067 C10.000002,7.1192966 8.8807135,6.0000095 7.5000019,6.0000095 z M14.500001,6.0000048 C13.119289,6.0000048 12.000001,7.1192918 12.000001,8.5000019 C12.000001,9.8807125 13.119289,11 14.500001,11 C15.880713,11 17,9.8807125 17,8.5000019 C17,7.1192918 15.880713,6.0000048 14.500001,6.0000048 z M11,0 C17.075132,0 22,4.9248676 22,11 C22,17.075132 17.075132,22 11,22 C4.9248676,22 0,17.075132 0,11 C0,4.9248676 4.9248676,0 11,0 z" });
			this.Add(new IconItem() { Path = "M10.929339,14.627753 C10.547352,14.627753 10.229825,14.739948 9.976758,14.964338 C9.723691,15.188728 9.5971584,15.468022 9.5971584,15.802219 C9.5971584,16.126869 9.723691,16.40855 9.976758,16.647261 C10.229825,16.876427 10.547352,16.991009 10.929339,16.991009 C11.311327,16.991009 11.626466,16.878813 11.874758,16.654423 C12.118275,16.430033 12.240033,16.145966 12.240033,15.802219 C12.240033,15.463247 12.115888,15.183953 11.867596,14.964338 C11.619304,14.739948 11.306552,14.627753 10.929339,14.627753 z M10.993799,6.3850083 C10.53064,6.3850093 10.081804,6.4399123 9.647294,6.5497203 C9.2127829,6.6595283 8.8116961,6.8242397 8.4440336,7.0438557 L8.4440336,9.1994295 C8.8021469,8.8843298 9.1817465,8.6491976 9.5828333,8.4940338 C9.9839201,8.338871 10.370683,8.2612896 10.74312,8.2612886 C10.915014,8.2612896 11.071391,8.2875471 11.212249,8.340065 C11.353106,8.3925819 11.472477,8.4641943 11.570362,8.5549059 C11.668246,8.6456175 11.74345,8.7542315 11.795973,8.8807487 C11.848496,9.007267 11.874758,9.1445265 11.874758,9.2925282 C11.874758,9.4644003 11.850883,9.6207581 11.803135,9.7615976 C11.755386,9.9024391 11.683764,10.038505 11.588267,10.169796 C11.49277,10.301088 11.376981,10.432381 11.240897,10.563672 C11.104815,10.694963 10.946051,10.836998 10.764607,10.989774 C10.592712,11.133001 10.442305,11.277423 10.313384,11.423038 C10.184464,11.568652 10.077029,11.721429 9.9910822,11.881366 C9.9051352,12.041303 9.8406754,12.211982 9.7977018,12.393404 C9.7547283,12.574825 9.7332411,12.775344 9.7332411,12.99496 C9.7332411,13.133413 9.7463722,13.280221 9.7726336,13.435384 C9.7988949,13.590548 9.8359003,13.730194 9.8836489,13.854324 L11.767324,13.854324 C11.714801,13.773162 11.67302,13.672903 11.641984,13.553547 C11.610948,13.43419 11.595429,13.317222 11.595429,13.20264 C11.595429,13.035542 11.616917,12.886346 11.65989,12.755054 C11.702864,12.623761 11.76613,12.499631 11.84969,12.382662 C11.933249,12.265693 12.038297,12.14753 12.164829,12.028173 C12.291363,11.908817 12.43819,11.779913 12.605309,11.641459 C12.853601,11.436167 13.073243,11.236841 13.264237,11.043485 C13.455231,10.850127 13.615188,10.648416 13.744109,10.438348 C13.87303,10.228281 13.970914,10.005085 14.037762,9.7687597 C14.104609,9.5324335 14.138033,9.2686558 14.138034,8.9774265 C14.138033,8.5190983 14.058055,8.1264162 13.898098,7.7993803 C13.73814,7.4723439 13.516109,7.2037926 13.232007,6.9937253 C12.947904,6.7836595 12.614859,6.6296892 12.232871,6.531817 C11.850883,6.4339447 11.43786,6.3850093 10.993799,6.3850083 z M11,0 C17.075132,0 22,4.9248676 22,11 C22,17.075132 17.075132,22 11,22 C4.9248676,22 0,17.075132 0,11 C0,4.9248676 4.9248676,0 11,0 z" });
			this.Add(new IconItem() { Path = "M5.1101694,17.805326 C6.6886616,19.172667 8.7477131,20 11,20 C15.970563,20 20,15.970563 20,11 C20,9.2137041 19.479597,7.5489545 18.582129,6.1490912 z M11,2 C6.0294371,2 2,6.0294371 2,11 C2,12.941627 2.6148434,14.739648 3.6604521,16.209988 L17.209465,4.4851823 C15.594427,2.9453831 13.407617,2 11,2 z M11,0 C17.075132,0 22,4.9248676 22,11 C22,17.075132 17.075132,22 11,22 C4.9248676,22 0,17.075132 0,11 C0,4.9248676 4.9248676,0 11,0 z" });
			this.Add(new IconItem() { Path = "M12.291727,4.0950155 L8.916604,4.1575046 L5.8539929,11.343703 L11.645829,11.343703 L9.2081804,17.905016 L16.145994,9.2815771 L9.7291336,9.2815771 z M11,0 C17.075132,0 22,4.9248676 22,11 C22,17.075132 17.075132,22 11,22 C4.9248676,22 0,17.075132 0,11 C0,4.9248676 4.9248676,0 11,0 z" });
			this.Add(new IconItem() { Path = "M10.000001,0 L13.250001,5.6374998 L20.000002,5.5 L16.5,11 L20.000002,16.5 L13.250001,16.362499 L10.000001,22 L6.750001,16.362499 L2.3395899E-08,16.5 L3.5000002,11 L2.3395899E-08,5.5 L6.750001,5.6374998 z" });
			this.Add(new IconItem() { Path = "M5.0000029,11.125 L9.0000029,16.125 L13.000003,11.125 z M6,2.7729216 C5.4477153,2.7729216 5,3.2240574 5,3.7805619 L5,8.3111229 L13,8.3111229 L13,3.7805619 C13,3.2240574 12.552285,2.7729216 12,2.7729216 z M5,-0.25 L13,-0.25 C14.656855,-0.25 16,1.103408 16,2.7729216 L16,8.3111229 L18,8.3111229 L18,19.75 L0,19.75 L0,8.3111229 L2,8.3111229 L2,2.7729216 C2,1.103408 3.3431458,-0.25 5,-0.25 z" });
			this.Add(new IconItem() { Path = "M14.791829,6.7480192 L10.833336,11.993596 L8.4582176,9.415185 L4.5830121,9.4152012 L10.958344,16.252018 L18.292011,6.7480192 z M11,0 C17.075132,0 22,4.9248676 22,11 C22,17.075132 17.075132,22 11,22 C4.9248676,22 0,17.075132 0,11 C0,4.9248676 4.9248676,0 11,0 z" });
			this.Add(new IconItem() { Path = "M6.6679673,20 L13.667967,20 L13.667967,22 L6.6679673,22 z M19,9 C19.552284,9 20,9.4477158 20,10 C20,10.552285 19.552284,11 19,11 C18.447716,11 18,10.552285 18,10 C18,9.4477158 18.447716,9 19,9 z M1,9 C1.5522847,9 2,9.4477158 2,10 C2,10.552285 1.5522847,11 1,11 C0.44771528,11 0,10.552285 0,10 C0,9.4477158 0.44771528,9 1,9 z M18,5 C18.552286,5 19,5.4477153 19,6 C19,6.5522852 18.552286,7 18,7 C17.447716,7 17,6.5522852 17,6 C17,5.4477153 17.447716,5 18,5 z M2,5 C2.5522847,5 3,5.4477153 2.9999998,6 C3,6.5522852 2.5522847,7 2,7 C1.4477153,7 1,6.5522852 1,6 C1,5.4477153 1.4477153,5 2,5 z M10.000975,3.0000005 C13.866968,3.0000005 17.000975,6.1340075 17.000975,10.000002 C17.000975,12.114216 16.063681,14.009516 14.581955,15.293034 L14.499365,15.362867 L13.582525,19.000002 L6.6690493,19.000002 L5.6982193,15.521532 L5.679266,15.507 C4.0484495,14.225405 3.0009751,12.235029 3.0009751,10.000002 C3.0009751,6.1340075 6.1349821,3.0000005 10.000975,3.0000005 z M15,2 C15.552286,2 16,2.4477153 16,3.0000002 C16,3.5522847 15.552286,4 15,4 C14.447716,4 14,3.5522847 14,3.0000002 C14,2.4477153 14.447716,2 15,2 z M5,2 C5.5522847,2 6,2.4477153 6,3.0000002 C6,3.5522847 5.5522847,4 5,4 C4.4477153,4 4,3.5522847 4,3.0000002 C4,2.4477153 4.4477153,2 5,2 z M10,0 C10.552284,0 11,0.44771528 11,1 C11,1.5522847 10.552284,2 10,2 C9.4477158,2 9,1.5522847 9,1 C9,0.44771528 9.4477158,0 10,0 z" });
			this.Add(new IconItem() { Path = "M10.000001,5 L12.000001,5 L12.041668,11 L16.373001,15.877792 L15.143854,16.982 L10.000002,11 z M11,2 C6.0294371,2 2,6.0294371 2,11 C2,15.970563 6.0294371,20 11,20 C15.970563,20 20,15.970563 20,11 C20,6.0294371 15.970563,2 11,2 z M11,0 C17.075132,0 22,4.9248676 22,11 C22,17.075132 17.075132,22 11,22 C4.9248676,22 0,17.075132 0,11 C0,4.9248676 4.9248676,0 11,0 z" });
			this.Add(new IconItem() { Path = "M5.0000024,12.000002 L5.0000024,16.000002 L9.0000019,16.000002 L9.0000019,12.000002 z M10.999999,0 L22,11.002 L19,11.002 L19,22 L17.000002,22 L17.000002,16.000004 L13.000003,16.000004 L13.000003,22 L3,22 L3,11.002 L0,11.002 z" });
		
		}
	}
}

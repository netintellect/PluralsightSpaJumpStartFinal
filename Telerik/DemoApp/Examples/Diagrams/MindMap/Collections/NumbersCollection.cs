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
	public class NumbersCollection : ObservableCollection<IconItem>
	{
		public NumbersCollection()
		{
			this.Add(new IconItem() { Name = "None", Path = string.Empty });
			this.Add(new IconItem() { Name = "1", Path = "M11.582303,5.4079895 L7.9490356,6.1404114 L7.9490356,7.6404114 L9.7363691,7.2536926 L9.7363691,12.486115 L7.9959168,12.486115 L7.9959168,13.950958 L13.311035,13.950958 L13.311035,12.486115 L11.582303,12.486115 z M0.99999994,0 L19,0 C19.552284,0 20,0.44771525 20,0.99999994 L20,19 C20,19.552284 19.552284,20 19,20 L0.99999994,20 C0.44771525,20 0,19.552284 0,19 L0,0.99999994 C0,0.44771525 0.44771525,0 0.99999994,0 z" });
			this.Add(new IconItem() { Name = "2", Path = "M9.5158472,5.4079895 C8.5979242,5.4079895 7.7737465,5.6443176 7.0433145,6.1169739 L7.0433145,7.7458801 C7.7034378,7.1716619 8.3948097,6.8845525 9.1174297,6.884552 C9.949419,6.8845525 10.365414,7.2712712 10.365414,8.0447083 C10.365414,8.3923645 10.266786,8.7234192 10.06953,9.0378723 C9.8722744,9.3523254 9.5314713,9.7419739 9.0471201,10.206818 L6.6390381,12.509552 L6.6390381,13.950958 L12.170011,13.950958 L12.170011,12.415802 L8.760026,12.415802 L8.760026,12.380646 L10.488455,10.84549 C11.664176,9.7986145 12.252037,8.7849426 12.252038,7.8044739 C12.252037,7.0700994 12.010839,6.4870915 11.528441,6.0554504 C11.046043,5.6238098 10.375179,5.4079895 9.5158472,5.4079895 z M0.99999994,0 L19,0 C19.552284,0 20,0.44771525 20,0.99999994 L20,19 C20,19.552284 19.552284,20 19,20 L0.99999994,20 C0.44771525,20 0,19.552284 0,19 L0,0.99999994 C0,0.44771525 0.44771525,0 0.99999994,0 z" });
			this.Add(new IconItem() { Name = "3", Path = "M9.2401648,5.4079895 C8.4549313,5.4079895 7.7673626,5.5564189 7.1774607,5.8532772 L7.1774607,7.3649111 C7.7087631,7.0016508 8.2556925,6.8200202 8.8182487,6.8200197 C9.6581755,6.8200202 10.078139,7.161798 10.078139,7.8453526 C10.078139,8.5718746 9.531209,8.9351349 8.4373512,8.9351349 L7.7400165,8.9351349 L7.7400165,10.353024 L8.4959507,10.353024 C9.0663195,10.353024 9.5146065,10.454581 9.8408108,10.657695 C10.167015,10.860808 10.330117,11.149855 10.330117,11.524834 C10.330117,11.888094 10.198268,12.171282 9.9345703,12.374395 C9.6708717,12.577509 9.3026714,12.679066 8.8299685,12.679066 C8.0798941,12.679066 7.4235787,12.473999 6.8610229,12.063866 L6.8610229,13.675103 C7.4040456,13.956337 8.1091938,14.096954 8.9764671,14.096954 C9.988286,14.096954 10.781334,13.868452 11.355609,13.411446 C11.929885,12.95444 12.217023,12.333382 12.217023,11.548269 C12.217023,11.028768 12.045131,10.590316 11.701346,10.232914 C11.357563,9.8755121 10.888766,9.6597042 10.294957,9.5854893 L10.294957,9.5561943 C11.408349,9.2788658 11.965045,8.5914049 11.965045,7.4938102 C11.965045,6.8766575 11.725763,6.3747325 11.2472,5.9880352 C10.768637,5.6013384 10.099626,5.4079895 9.2401648,5.4079895 z M0.99999994,0 L19,0 C19.552284,0 20,0.44771525 20,0.99999994 L20,19 C20,19.552284 19.552284,20 19,20 L0.99999994,20 C0.44771525,20 0,19.552284 0,19 L0,0.99999994 C0,0.44771525 0.44771525,0 0.99999994,0 z" });
			this.Add(new IconItem() { Name = "4", Path = "M9.8791523,7.3996806 L9.9143057,7.3996806 C9.8986816,7.7004857 9.8908701,7.9680848 9.8908701,8.2024775 L9.8908701,10.845263 L7.7640581,10.845263 L9.562767,8.0559816 C9.7190065,7.7590842 9.8244677,7.5403171 9.8791523,7.3996806 z M9.7561131,5.5479736 L6.2290039,10.985898 L6.2290039,12.163725 L9.8908701,12.163725 L9.8908701,13.950974 L11.578258,13.950974 L11.578258,12.163725 L12.586003,12.163725 L12.586003,10.845263 L11.578258,10.845263 L11.578258,5.5479736 z M0.99999994,0 L19,0 C19.552284,0 20,0.44771525 20,0.99999994 L20,19 C20,19.552284 19.552284,20 19,20 L0.99999994,20 C0.44771525,20 0,19.552284 0,19 L0,0.99999994 C0,0.44771525 0.44771525,0 0.99999994,0 z" });
			this.Add(new IconItem() { Name = "5", Path = "M7.2012196,5.5479736 L7.2012196,10.241427 C7.7441573,10.171113 8.2070217,10.135956 8.5898132,10.135956 C9.7655277,10.135956 10.353386,10.55198 10.353386,11.384028 C10.353386,11.782474 10.215698,12.09791 9.9403229,12.330336 C9.6649475,12.562762 9.2831335,12.678976 8.7948799,12.678976 C8.1464787,12.678976 7.5351849,12.503191 6.9609985,12.151622 L6.9609985,13.733685 C7.5117488,13.975877 8.1913977,14.096973 8.9999466,14.096973 C9.9959841,14.096973 10.785002,13.828413 11.367001,13.291293 C11.948998,12.754172 12.239998,12.061776 12.239999,11.214103 C12.239998,10.448462 11.995871,9.8390751 11.507618,9.3859415 C11.019364,8.932807 10.34362,8.7062397 9.4803877,8.7062397 C9.2616501,8.7062397 9.0292416,8.7179594 8.7831612,8.7413969 L8.7831612,7.0597229 L11.853301,7.0597229 L11.853301,5.5479736 z M0.99999994,0 L19,0 C19.552284,0 20,0.44771525 20,0.99999994 L20,19 C20,19.552284 19.552284,20 19,20 L0.99999994,20 C0.44771525,20 0,19.552284 0,19 L0,0.99999994 C0,0.44771525 0.44771525,0 0.99999994,0 z" });
			this.Add(new IconItem() { Name = "6", Path = "M9.5860147,9.9194546 C10.3243,9.9194546 10.693442,10.370602 10.693442,11.272895 C10.693442,11.69084 10.593832,12.029688 10.394612,12.289439 C10.195393,12.54919 9.9297657,12.679066 9.5977335,12.679066 C9.2578878,12.679066 8.985425,12.533566 8.7803459,12.242566 C8.5752668,11.951568 8.4727278,11.601001 8.4727278,11.190867 C8.4727278,10.819795 8.5733137,10.515124 8.7744865,10.276856 C8.9756594,10.038589 9.2461691,9.9194546 9.5860147,9.9194546 z M10.394612,5.4079895 C9.2227316,5.4079895 8.2949924,5.8425355 7.6113944,6.7116275 C6.9277973,7.580719 6.5859985,8.741787 6.5859985,10.19483 C6.5859985,11.429135 6.851625,12.388066 7.3828778,13.071622 C7.9141307,13.755177 8.6524162,14.096954 9.5977335,14.096954 C10.441488,14.096954 11.136805,13.817674 11.683682,13.25911 C12.230559,12.700548 12.503999,11.999416 12.503999,11.155713 C12.503999,10.370602 12.297943,9.7397776 11.885832,9.2632418 C11.47372,8.786706 10.9161,8.5484381 10.212971,8.5484381 C9.4395294,8.5484381 8.851635,8.8452969 8.4492893,9.4390135 L8.4141331,9.4390135 C8.4297581,8.6421833 8.6280012,8.0064764 9.0088634,7.5318937 C9.3897238,7.0573115 9.8907032,6.8200202 10.511801,6.8200197 C11.01571,6.8200202 11.480556,6.9411073 11.90634,7.1832805 L11.90634,5.6364923 C11.546963,5.4841571 11.043054,5.4079895 10.394612,5.4079895 z M0.99999994,0 L19,0 C19.552284,0 20,0.44771525 20,0.99999994 L20,19 C20,19.552284 19.552284,20 19,20 L0.99999994,20 C0.44771525,20 0,19.552284 0,19 L0,0.99999994 C0,0.44771525 0.44771525,0 0.99999994,0 z" });
			this.Add(new IconItem() { Name = "7", Path = "M7.5620117,5.5479736 L7.5620117,7.0598102 L11.476304,7.0598102 L8.4878473,13.950974 L10.444994,13.950974 L13.410011,6.4035091 L13.410011,5.5479736 z M0.99999994,0 L19,0 C19.552284,0 20,0.44771525 20,0.99999994 L20,19 C20,19.552284 19.552284,20 19,20 L0.99999994,20 C0.44771525,20 0,19.552284 0,19 L0,0.99999994 C0,0.44771525 0.44771525,0 0.99999994,0 z" });
			this.Add(new IconItem() { Name = "8", Path = "M9.4097462,10.288627 C10.27305,10.585485 10.704702,11.054212 10.704702,11.694803 C10.704702,12.0151 10.591418,12.272899 10.364849,12.468201 C10.138281,12.663504 9.8394451,12.761154 9.4683418,12.761154 C9.1245823,12.761154 8.8325825,12.661551 8.5923424,12.462341 C8.3521013,12.263133 8.2319813,12.011193 8.2319813,11.706521 C8.2319813,11.069836 8.6245689,10.597204 9.4097462,10.288627 z M9.503499,6.738029 C9.8042879,6.7380295 10.045506,6.8229856 10.227151,6.9928985 C10.408796,7.1628122 10.499619,7.3903394 10.499619,7.6754804 C10.499619,8.1988907 10.163672,8.5992603 9.4917793,8.8765898 C8.8198872,8.6070728 8.4839411,8.2106085 8.4839411,7.6871986 C8.4839411,7.4098697 8.5806227,7.1823421 8.7739878,7.0046167 C8.9673519,6.8268919 9.2105217,6.7380295 9.503499,6.738029 z M9.503499,5.4080195 C8.6870708,5.4080195 8.0210381,5.6179695 7.5053992,6.0378699 C6.9897609,6.4577703 6.7319417,6.9919224 6.7319417,7.640326 C6.7319417,8.5230923 7.2124228,9.1617317 8.1733856,9.556242 L8.1733856,9.5855379 C7.0444498,10.058169 6.4799819,10.796412 6.4799819,11.800266 C6.4799819,12.491637 6.7407308,13.047273 7.262229,13.467173 C7.7837272,13.887073 8.4702682,14.097023 9.3218536,14.097023 C10.306254,14.097023 11.072876,13.88219 11.621718,13.452525 C12.170561,13.02286 12.444982,12.436953 12.444983,11.694803 C12.444982,11.214359 12.287751,10.781765 11.97329,10.397019 C11.658829,10.012274 11.216434,9.7359209 10.646107,9.5679607 L10.646107,9.5445242 C11.708634,9.1109524 12.239898,8.4352064 12.239899,7.5172853 C12.239898,6.8962245 11.991845,6.3894148 11.495738,5.9968562 C10.999632,5.6042986 10.335552,5.4080195 9.503499,5.4080195 z M0.99999994,0 L19,0 C19.552284,0 20,0.44771525 20,0.99999994 L20,19 C20,19.552284 19.552284,20 19,20 L0.99999994,20 C0.44771525,20 0,19.552284 0,19 L0,0.99999994 C0,0.44771525 0.44771525,0 0.99999994,0 z" });
			this.Add(new IconItem() { Name = "9", Path = "M9.3690815,6.820056 C9.6971998,6.8200564 9.9677029,6.9665332 10.18059,7.2594862 C10.393476,7.5524402 10.49992,7.9196086 10.49992,8.3609915 C10.49992,8.7125359 10.398359,9.0045128 10.195238,9.2369232 C9.992116,9.4693327 9.730402,9.5855379 9.4100962,9.5855379 C9.0585403,9.5855379 8.7802248,9.4634733 8.5751505,9.219346 C8.3700762,8.9752178 8.267539,8.640274 8.267539,8.2145147 C8.267539,7.8043804 8.3710527,7.4694366 8.5780802,7.2096839 C8.7851076,6.9499326 9.0487747,6.8200564 9.3690815,6.820056 z M9.4218149,5.4080195 C8.5468302,5.4080195 7.8339529,5.6785135 7.2831821,6.219501 C6.7324109,6.760489 6.4570255,7.4782252 6.4570255,8.3727102 C6.4570255,9.1382952 6.6826072,9.7613096 7.1337709,10.241754 C7.5849342,10.722198 8.1542597,10.96242 8.8417473,10.96242 C9.5995455,10.96242 10.163988,10.687043 10.535075,10.136291 L10.57023,10.148008 C10.566324,10.95656 10.387617,11.580551 10.034108,12.019981 C9.6805983,12.459413 9.1796312,12.679128 8.5312061,12.679128 C7.9101233,12.679128 7.3788834,12.534604 6.9374852,12.245556 L6.9374852,13.768914 C7.4374762,13.987654 8.0292616,14.097023 8.7128429,14.097023 C9.8651657,14.097023 10.76261,13.680052 11.405176,12.846111 C12.047742,12.01217 12.369025,10.845238 12.369025,9.3453159 C12.369025,8.0797567 12.102428,7.107151 11.569236,6.4274979 C11.036042,5.7478456 10.320235,5.4080195 9.4218149,5.4080195 z M0.99999994,0 L19,0 C19.552284,0 20,0.44771525 20,0.99999994 L20,19 C20,19.552284 19.552284,20 19,20 L0.99999994,20 C0.44771525,20 0,19.552284 0,19 L0,0.99999994 C0,0.44771525 0.44771525,0 0.99999994,0 z" });
			this.Add(new IconItem() { Name = "0", Path = "M9.4922066,6.8200936 C10.242237,6.8200941 10.617252,7.7966061 10.617252,9.749629 C10.617252,11.702653 10.234425,12.679165 9.4687681,12.679165 C8.6835794,12.679165 8.2909851,11.731949 8.2909851,9.8375158 C8.2909851,7.8259015 8.6913929,6.8200941 9.4922066,6.8200936 z M9.5742416,5.4080572 C8.546855,5.4080572 7.7626433,5.7898736 7.2216058,6.5535059 C6.6805677,7.3171387 6.410049,8.427433 6.410049,9.884388 C6.410049,12.692836 7.41009,14.09706 9.4101725,14.09706 C10.406306,14.09706 11.170986,13.718174 11.704211,12.960401 C12.237436,12.202627 12.504048,11.11284 12.504049,9.6910381 C12.504048,6.8357182 11.527446,5.4080572 9.5742416,5.4080572 z M0.99999994,0 L19,0 C19.552284,0 20,0.44771525 20,0.99999994 L20,19 C20,19.552284 19.552284,20 19,20 L0.99999994,20 C0.44771525,20 0,19.552284 0,19 L0,0.99999994 C0,0.44771525 0.44771525,0 0.99999994,0 z" });
		}
	}
}

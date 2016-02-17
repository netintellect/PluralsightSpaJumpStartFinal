using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.TileView.Common
{
	public class Countries : ObservableCollection<Country>
	{

		public Countries()
			: this(1)
		{

		}

		public Countries(int subDirCount)
		{
			Country austria = new Country("Austria", subDirCount);
			austria.PoliticalSystem = "Federal republic";
			austria.CapitalCity = "Vienna";
			austria.TotalArea = "83 870 sq. km";
			austria.Population = "8.3 million";
			austria.Currency = "euro";
			austria.OfficialLanguage = "German";
			austria.Description = "The Alps dominate the western and southern parts of Austria while the eastern provinces - including Vienna, the capital - lie in the Danube basin. Until the end of World War I, Austria had been the centre of a vast empire, which controlled much of central Europe for centuries. Austria is now a federal republic, consisting of nine states. Vienna hosts a number of international organisations, including the Secretariat of the Organisation for Security and Cooperation in Europe, the International Atomic Energy Agency and the Organisation of Petroleum Exporting Countries. The Austrian Parliament has two chambers. The National Council, or Nationalrat, has 183 members, who are elected by direct popular vote to serve a five-year term. The Federal Council, or Bundesrat, is the upper house with about 62 members who represent each province. Its members serve a four or six-year term.";
			this.Add(austria);

			Country belgium = new Country("Belgium", subDirCount);
			belgium.PoliticalSystem = "Constitutional monarchy";
			belgium.CapitalCity = "Brussels";
			belgium.TotalArea = "30 528 sq. km";
			belgium.Population = "10.7 million";
			belgium.Currency = "euro";
			belgium.OfficialLanguage = "German, French, Dutch";
			belgium.Description = "Belgium is a federal state divided into three regions: Dutch-speaking Flanders in the north, francophone Wallonia in the south and Brussels, the bilingual capital, where French and Dutch share official status. There is also a small German-speaking minority of some 70 000 in the eastern part of the country. Belgium’s landscape varies widely: 67 kilometres of seacoast and flat coastal plains along the North Sea, a central plateau and the rolling hills and forests of the Ardennes region in the southeast. Brussels hosts several international organisations: most of the European institutions are located here as well as the NATO headquarters. Independent since 1830, Belgium is a constitutional monarchy. The two houses of Parliament are the Chamber of Representatives, whose members are elected for a maximum period of four years, and the Senate or upper house, whose members are elected or co-opted. Given its political make-up, Belgium is generally run by coalition governments.";
			this.Add(belgium);

			Country bulgaria = new Country("Bulgaria", subDirCount);
			bulgaria.PoliticalSystem = "Republic";
			bulgaria.CapitalCity = "Sofia";
			bulgaria.TotalArea = "111 910 sq. km";
			bulgaria.Population = "7.6 million";
			bulgaria.Currency = "lev";
			bulgaria.OfficialLanguage = "Bulgarian";
			bulgaria.Description = "Located in the heart of the Balkans, Bulgaria offers a highly diverse landscape: the north is dominated by the vast lowlands of the Danube and the south by the highlands and elevated plains. In the east, the Black Sea coast attracts tourists all year round. Founded in 681, Bulgaria is one of the oldest states in Europe. Its history is marked by its location near Europe’s frontier with Asia. Some 85% of the population are Orthodox Christians and 13% Muslims. Around 10% of the population are of Turkish origin while 3% are Roma. Similarly, its traditional dishes are a mixture of east and west. The most famous Bulgarian food must be yoghurt, with its reputed gift of longevity for those who consume it regularly.";
			this.Add(bulgaria);

			Country cyprus = new Country("Cyprus", subDirCount);
			cyprus.PoliticalSystem = "Republic";
			cyprus.CapitalCity = "Nicosia";
			cyprus.TotalArea = "9 250 sq. km";
			cyprus.Population = "0.8 million";
			cyprus.Currency = "euro";
			cyprus.OfficialLanguage = "Greek, English";
			cyprus.Description = "Cyprus is the largest island in the eastern Mediterranean and is situated south of Turkey. The two main mountain ranges are the Pentadactylos in the north and the Troodos in central and south-western part of the island. Between them is the fertile plain of Messaoria. Cyprus has long been a crossing point between Europe, Asia and Africa and still has many traces of successive civilisations – Roman theatres and villas, Byzantine churches and monasteries, Crusader castles and pre-historic habitats. The island’s main economic activities are tourism, clothing and craft exports and merchant shipping. Traditional crafts include embroidery, pottery and copperwork.";
			this.Add(cyprus);

			Country czechRepublic = new Country("CzechRepublic", subDirCount);
			czechRepublic.PoliticalSystem = "Republic";
			czechRepublic.CapitalCity = "Prague";
			czechRepublic.TotalArea = "78 866 sq. km";
			czechRepublic.Population = "10.5 million";
			czechRepublic.Currency = "Czech koruna";
			czechRepublic.OfficialLanguage = "Czech";
			czechRepublic.Description = "The Czech Republic became an independent state in January 1993 after Czechoslovakia split into its two constituent parts. Before World War II, Czechoslovakia was one of the 10 most industrialised states in the world, and the only central European country to remain a democracy until 1938. The Czech capital, Prague, is more than 1 000 years old and has a wealth of historic architecture of different styles. Because of this, the city has become a favoured location for many international film makers.";
			this.Add(czechRepublic);

			Country denmark = new Country("Denmark", subDirCount);
			denmark.PoliticalSystem = "Constitutional monarchy";
			denmark.CapitalCity = "Copenhagen";
			denmark.TotalArea = "43 094 sq. km";
			denmark.Population = "5.5 million";
			denmark.Currency = "Danish krone";
			denmark.OfficialLanguage = "Danish";
			denmark.Description = "Denmark consists of the peninsula of Jutland (Jylland) and some 400 named islands. Of these, 82 are inhabited, the largest being Funen (Fyn) and Zealand (Sjælland). Denmark has a large fishing industry, and possesses a merchant fleet of considerable size. The manufacturing sector’s main areas of activity include food products, chemicals, machinery, metal products, electronic and transport equipment, beer and paper and wood products. Tourism is also an important economic activity.";
			this.Add(denmark);

			Country estonia = new Country("Estonia", subDirCount);
			estonia.PoliticalSystem = "Republic";
			estonia.CapitalCity = "Tallinn";
			estonia.TotalArea = "45 000 sq. km";
			estonia.Population = "1.3 million";
			estonia.Currency = "Estonian kroon";
			estonia.OfficialLanguage = "Estonian";
			estonia.Description = "Estonia, the most northerly of the Baltic states, regained its independence from the Soviet Union in 1991. It is a mainly flat country on the eastern shores of the Baltic Sea, with many lakes and islands. Much of the land is farmed or forested. The Estonian language is closely related to Finnish, but bears no resemblance to the languages of the other Baltic republics, Latvia and Lithuania, or to Russian. About one quarter of the population is of Russian-speaking origin. The capital, Tallinn, is one of the best-preserved mediaeval cities in Europe, and tourism accounts for 15% of Estonian GDP. The economy is driven by engineering, food products, metals, chemicals and wood products.";
			this.Add(estonia);

			Country finland = new Country("Finland", subDirCount);
			finland.PoliticalSystem = "Republic";
			finland.CapitalCity = "Helsinki";
			finland.TotalArea = "338 000 sq. km";
			finland.Population = "5.3 million";
			finland.Currency = "euro";
			finland.OfficialLanguage = "Finnish, Swedish";
			finland.Description = "Finland, a country of forests and lakes, is perhaps best known for its unspoilt natural beauty. In the far north, the White Nights, during which the sun does not set, last for around 10 weeks of the summer. In winter the same area goes through nearly eight weeks when the sun never rises above the horizon. As a result of Finland being a part of Sweden for seven centuries (from the 12th century until 1809) some 6% of the population is Swedish-speaking. Finland became an independent state following the Russian revolution in 1917. Since this date Finland has been a republic. It has a one-chamber parliament whose 200 members are elected every four years. The country has developed a modern, competitive economy, and is a world leader in telecommunications equipment. Main exports include telecoms equipment and engineering products, paper, pulp and lumber, glassware, stainless steel and ceramics.";
			this.Add(finland);

			Country france = new Country("France", subDirCount);
			france.PoliticalSystem = "Republic";
			france.CapitalCity = "Paris";
			france.TotalArea = "550 000 sq. km";
			france.Population = "64.3 million";
			france.Currency = "euro";
			france.OfficialLanguage = "French";
			france.Description = "France is the largest country in the EU, stretching from the North Sea to the Mediterranean. The landscape is diverse, with mountains in the east and south, including the Alpine peak of Mont Blanc (4 810 m) which is western Europe's highest point. Lowland France consists of four river basins, the Seine in the north, the Loire and the Garonne flowing westwards and the Rhône, which flows from Lake Geneva to the Mediterranean Sea. The church of Sacré Coeur in ParisThe president of the Republic has an important political role. He chairs the meetings of the Council of Ministers (cabinet), and retains overall responsibility in key areas of foreign affairs and defence. The day-to-day running of the country is in the hands of the prime minister. The president is elected by direct popular vote for a period of five years. The parliament consists of a National Assembly, directly elected every five years, and a Senate whose members are chosen by an electoral college.";
			this.Add(france);

			Country germany = new Country("Germany", subDirCount);
			germany.PoliticalSystem = "Federal republic";
			germany.CapitalCity = "Berlin";
			germany.TotalArea = "356 854 sq. km";
			germany.Population = "82 million";
			germany.Currency = "euro";
			germany.OfficialLanguage = "German";
			germany.Description = "Germany has the largest population of any EU country. Its territory stretches from the North Sea and the Baltic in the north to the Alps in the south and is traversed by some of Europe's major rivers such as the Rhine, Danube and Elbe. Germany is a federal republic. The lawmakers at the national level are the Bundestag, whose members are elected every four years by popular vote and the Bundesrat, which consists of 69 representatives of the 16 states (Bundesländer). After the Second World War, Germany was divided into the democratic West and the Communist East (German Democratic Republic). The Berlin Wall became the symbol of this division. It fell in 1989 and Germany was reunited a year later. German is the most widely spoken first language in the European Union. Germany is the world's third largest economy, producing automobiles, precision engineering products, electronic and communications equipment, chemicals and pharmaceuticals, and much more besides. Its companies have invested heavily in the central and east European countries which joined the EU in 2004.";
			this.Add(germany);

			Country greece = new Country("Greece", subDirCount);
			greece.PoliticalSystem = "Republic";
			greece.CapitalCity = "Athens";
			greece.TotalArea = "131 957 sq. km";
			greece.Population = "11.2 million";
			greece.Currency = "euro";
			greece.OfficialLanguage = "Greek";
			greece.Description = "Located near the crossroads of Europe and Asia, Greece forms the southern extremity of the Balkan peninsula in south-east Europe. Its territory includes more than 2 000 islands in the Aegean and Ionian seas, of which only around 165 are inhabited. Mount Olympus is the highest point in the country. Greece is one of the cradles of European civilisation, whose ancient scholars made great advances in philosophy, medicine, mathematics and astronomy. Their city-states were pioneers in developing democratic forms of government. The historical and cultural heritage of Greece continues to resonate throughout the modern world - in literature, art, philosophy and politics.";
			this.Add(greece);

			Country hungary = new Country("Hungary", subDirCount);
			hungary.PoliticalSystem = "Republic";
			hungary.CapitalCity = "Budapest";
			hungary.TotalArea = "93 000 sq. km";
			hungary.Population = "10 million";
			hungary.Currency = "forint";
			hungary.OfficialLanguage = "Hungarian";
			hungary.Description = "Hungary is a landlocked state with many neighbours – Slovakia, Ukraine, Romania, Serbia, Croatia, Slovenia and Austria. It is mostly flat, with low mountains in the north. Lake Balaton, a popular tourist centre, is the largest lake in central Europe. The ancestors of ethnic Hungarians were the Magyar tribes, who moved into the Carpathian Basin in 896. Hungary became a Christian kingdom under St Stephen in the year 1000. The Hungarian language is unlike any of the country’s neighbouring languages and is only distantly related to Finnish and Estonian. The capital city, Budapest, was originally was two separate cities: Buda and Pest. It straddles the River Danube, is rich in history and culture and famed for its curative springs. Hungary has a single-chamber parliament or national assembly whose 386 members are elected by voters every four years.";
			this.Add(hungary);

			Country ireland = new Country("Ireland", subDirCount);
			ireland.PoliticalSystem = "Republic";
			ireland.CapitalCity = "Dublin";
			ireland.TotalArea = "70 000 sq. km";
			ireland.Population = "4.5 million";
			ireland.Currency = "euro";
			ireland.OfficialLanguage = "English, Irish";
			ireland.Description = "Since joining the European Union in 1973, Ireland (Éire) has transformed itself from a largely agricultural society into a modern, technologically advanced Celtic Tiger economy. Agricultural lowlands make up most of the interior, which is broken in places by low hills and includes considerable areas of bogs and lakes. There are coastal mountains to the west, rising to over 1 000m in places. Nearly a third of the population lives in Dublin. The 9th century Book of KellsThe Dáil, or lower house of Parliament, is composed of 166 members while the Seanad, or upper house, has 60 members. Parliamentary elections are held every five years. The President, elected for a seven-year period, mainly performs ceremonial duties.";
			this.Add(ireland);

			Country italy = new Country("Italy", subDirCount);
			italy.PoliticalSystem = "Republic";
			italy.CapitalCity = "Rome";
			italy.TotalArea = "301 263 sq. km";
			italy.Population = "60 million";
			italy.Currency = "euro";
			italy.OfficialLanguage = "Italian";
			italy.Description = "Italy is mainly mountainous, except for the Po plain in the north, and runs from the Alps to the central Mediterranean Sea. It includes the islands of Sicily, Sardinia, Elba and about 70 other smaller ones. There are two small independent states within peninsular Italy: the Vatican City in Rome, and the Republic of San Marino. Italy has a two-chamber parliament, consisting of the Senate (Senato della Repubblica) or upper house and the Chamber of Deputies (Camera dei Deputati). Elections take place every five years. The heart of RomeThe country’s main economic sectors are tourism, fashion, engineering, chemicals, motor vehicles and food. Italy's northern regions are per capita amongst the richest in Europe.";
			this.Add(italy);

			Country latvia = new Country("Latvia", subDirCount);
			latvia.PoliticalSystem = "Republic";
			latvia.CapitalCity = "Riga";
			latvia.TotalArea = "65 000 sq. km";
			latvia.Population = "2.3 million";
			latvia.Currency = "lats";
			latvia.OfficialLanguage = "Latvian";
			latvia.Description = "Latvia regained independence from the Soviet Union in 1991. Situated on the Baltic coast, Latvia is a low-lying country with large forests that supply timber for construction and paper industries. The environment is rich in wildlife. Latvia also produces consumer goods, textiles and machine tools. The country attracts tourists from all over Europe. Ethnically, the population is 59% Latvian and 29% Russian, and more than a third live in the capital Riga. Founded in 1201, Riga is the largest city in the three Baltic states with a population of 730 000. Its Freedom Statue is one of the highest monuments in Europe, at 43 metres.";
			this.Add(latvia);

			Country lithuania = new Country("Lithuania", subDirCount);
			lithuania.PoliticalSystem = "Republic";
			lithuania.CapitalCity = "Vilnius";
			lithuania.TotalArea = "65 000 sq. km";
			lithuania.Population = "3.3 million";
			lithuania.Currency = "litas";
			lithuania.OfficialLanguage = "Lithuanian";
			lithuania.Description = "Lithuania is the southernmost of the three Baltic states – and the largest and most populous of them. Lithuania was the first occupied Soviet republic to break free from the Soviet Union and restore its sovereignty via the declaration of independence on 11 March 1990. The Lithuanian landscape is predominantly flat, with a few low hills in the western uplands and eastern highlands. The highest point is Aukštasis at 294 metres. Lithuania has 758 rivers, more than 2 800 lakes and 99 km of the Baltic Sea coastline, which are mostly devoted to recreation and nature preservation. Forests cover just over 30% of the country.";
			this.Add(lithuania);

			Country luxembourg = new Country("Luxemburg", subDirCount);
			luxembourg.PoliticalSystem = "Constitutional monarchy";
			luxembourg.CapitalCity = "Luxembourg";
			luxembourg.TotalArea = "2 586 sq. km";
			luxembourg.Population = "0.5 million";
			luxembourg.Currency = "euro";
			luxembourg.OfficialLanguage = "French , German";
			luxembourg.Description = "The Grand Duchy of Luxembourg is a small country surrounded by Belgium, France and Germany, and its history has been inextricably linked with that of its larger neighbours. It is largely made up of rolling hills and forests. Luxembourg by night Luxembourg has been under the control of many states and ruling houses in its long history, but it has been a separate, if not always autonomous, political unit since the 10th century. Today, Luxembourg is a hereditary Grand Duchy with a unicameral parliamentary system. Luxembourgish, the national language, is akin to German. German is the first foreign language for most Luxembourgers and is used in the media. French is the administrative language.";
			this.Add(luxembourg);

			Country netherlands = new Country("Netherlands", subDirCount);
			netherlands.PoliticalSystem = "Constitutional monarchy";
			netherlands.CapitalCity = "Amsterdam";
			netherlands.TotalArea = "41 526 sq. km";
			netherlands.Population = "16.4 million";
			netherlands.Currency = "euro";
			netherlands.OfficialLanguage = "Dutch";
			netherlands.Description = "The Netherlands, as the name indicates, is low-lying territory, with one-quarter of the country at or below sea level. Many areas are protected from flooding by dykes and sea walls. Much land has been reclaimed from the sea, the Flevoland polder being the most recent example. The Dutch Parliament (or Staten Generaal) consists of two chambers. The first, with 75 members, is indirectly elected and has limited powers. The second chamber, or lower house, is directly elected. Members of both houses serve a four-year term. Given the country’s multi-party system, all governments are coalitions.";
			this.Add(netherlands);

			Country uk = new Country("UK", subDirCount);
			uk.PoliticalSystem = "Constitutional monarchy";
			uk.CapitalCity = "London";
			uk.TotalArea = "244 820 sq. km";
			uk.Population = "61.7 million";
			uk.Currency = "pound sterling";
			uk.OfficialLanguage = "English";
			uk.Description = "The United Kingdom (UK) consists of England, Wales, Scotland (who together make up Great Britain) and Northern Ireland. The UK’s geography is varied, and includes cliffs along some coastlines, highlands and lowlands and many islands off the coast of Scotland. The highest mountain is Ben Nevis in Scotland which reaches a height of 1 344m. The United Kingdom is a constitutional monarchy and parliamentary democracy. The main chamber of parliament is the lower house, the House of Commons, which has 646 members elected by universal suffrage. About 700 people are eligible to sit in the upper house, the House of Lords, including life peers, hereditary peers, and bishops. There is a Scottish parliament in Edinburgh with wide-ranging local powers, and a Welsh Assembly in Cardiff which has more limited authority for Welsh affairs but can legislate in some areas.";
			this.Add(uk);
		}
	}
}

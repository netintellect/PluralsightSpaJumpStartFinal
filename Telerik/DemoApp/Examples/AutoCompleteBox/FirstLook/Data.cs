using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.AutoCompleteBox.FirstLook
{
    public class Data
    {
        ObservableCollection<Song> songs = new ObservableCollection<Song>();
        ObservableCollection<Movie> movies = new ObservableCollection<Movie>();
        ObservableCollection<FoodPlace> foodPlaces = new ObservableCollection<FoodPlace>();

        #region Songs manipulation
        public void EntrySongsData()
        {
            songs.Add(new Song()
            {
                 Title =  "Like a Rolling Stone",
                 Author = "Bob Dylan"
            });
            songs.Add(new Song()
            {
                 Title =  "Satisfaction",
                 Author = "The Rolling Stones"
            });
            songs.Add(new Song()
            {
                 Title =  "Imagine",
                 Author = "John Lennon"
            });

            songs.Add(new Song()
            {
                Title = "What's Going On",
                Author = "Marvin Gaye"
            });
            songs.Add(new Song()
            {
                Title = "Respect",
                Author = "Aretha Franklin"
            });
            songs.Add(new Song()
            {
                Title = "Good Vibrations",
                Author = "The Beach Boys"
            });

            songs.Add(new Song()
            {
                Title = "Johnny B. Goode",
                Author = "Chuck Berry"
            });
            songs.Add(new Song()
            {
                Title = "Hey Jude",
                Author = "The Beatles"
            });
            songs.Add(new Song()
            {
                Title = "Smells Like Teen Spirit",
                Author = "Nirvana"
            });
            songs.Add(new Song()
            {
                Title = "What'd I Say",
                Author = "Ray Charles"
            });
            songs.Add(new Song()
            {
                Title = "My Generation",
                Author = "The Who"
            });
            songs.Add(new Song()
            {
                Title = "A Change Is Gonna Come",
                Author = "Sam Cooke"
            });
            songs.Add(new Song()
            {
                Title = "Yesterday",
                Author = "The Beatles"
            });
            songs.Add(new Song()
            {
                Title = "Blowin' in the Wind",
                Author = "Bob Dylan"
            });
            songs.Add(new Song()
            {
                Title = "London Calling",
                Author = "The Clash"
            });
            songs.Add(new Song()
            {
                Title = "I Want to Hold Your Hand",
                Author = "The Beatles"
            });
            songs.Add(new Song()
            {
                Title = "Purple Haze",
                Author = "Jimi Hendrix"
            });
            songs.Add(new Song()
            {
                Title = "Maybellene",
                Author = "Chuck Berry"
            });
            songs.Add(new Song()
            {
                Title = "Hound Dog",
                Author = "Elvis Presley"
            });
            songs.Add(new Song()
            {
                Title = "Let It Be",
                Author = "The Beatles"
            });
            songs.Add(new Song()
            {
                Title = "Born to Run",
                Author = "Bruce Springsteen"
            });
            songs.Add(new Song()
            {
                Title = "Be My Baby",
                Author = "The Ronettes"
            });
            songs.Add(new Song()
            {
                Title = "In My Life",
                Author = "The Beatles"
            });
            songs.Add(new Song()
            {
                Title = "People Get Ready",
                Author = "The Impressions"
            });
            songs.Add(new Song()
            {
                Title = "A Day in the Life",
                Author = "The Beatles"
            });
            songs.Add(new Song()
            {
                Title = "God Only Knows",
                Author = "The Beach Boys"
            });
            songs.Add(new Song()
            {
                Title = "Stairway To Heaven",
                Author = "Led Zeppelin"
            });
            songs.Add(new Song()
            {
                Title = "Sympathy for the Devil",
                Author = "The Rolling Stones"
            });
            songs.Add(new Song()
            {
                Title = "River Deep",
                Author = "Mountain High, Ike and Tina Turner"
            });
            songs.Add(new Song()
            {
                Title = "You've Lost That Lovin' Feelin'",
                Author = "The Righteous Brothers"
            });
            songs.Add(new Song()
            {
                Title = "One",
                Author = "U2"
            });
            songs.Add(new Song()
            {
                Title = "No Woman, No Cry",
                Author = "Bob Marley and the Wailers"
            });
            songs.Add(new Song()
            {
                Title = "Dancing in the Street",
                Author = "Martha and the Vandellas"
            });
            songs.Add(new Song()
            {
                Title = "The Weight",
                Author = "The Band"
            });
            songs.Add(new Song()
            {
                Title = "The Message",
                Author = "Grandmaster Flash and the Furious Five"
            });
            songs.Add(new Song()
            {
                Title = "Crying",
                Author = "Roy Orbison"
            });
            songs.Add(new Song()
            {
                Title = "Every Breath You Take",
                Author = "The Police"
            });
            songs.Add(new Song()
            {
                Title = "Crazy",
                Author = "Patsy Cline"
            });
			songs.Add(new Song()
			{
				Title = "Thunder Road",
				Author = "Bruce Springsteen"
			});
			songs.Add(new Song()
			{
				Title = "Ring of Fire",
				Author = "Johnny Cash"
			});
			songs.Add(new Song()
			{
				Title = "My Girl",
				Author = "The Temptations"
			});
			songs.Add(new Song()
			{
				Title = "California Dreamin'",
				Author = "The Mamas and The Papas"
			});
			songs.Add(new Song()
			{
				Title = "In the Still of the Nite",
				Author = "The Five Satins"
			});
			songs.Add(new Song()
			{
				Title = "Suspicious Minds",
				Author = "Elvis Presley"
			});
			songs.Add(new Song()
			{
				Title = "Blitzkrieg Bop",
				Author = "Ramones"
			});
			songs.Add(new Song()
			{
				Title = "I Still Haven't Found What I'm Looking For",
				Author = "U2"
			});
			songs.Add(new Song()
			{
				Title = "Good Golly",
				Author = "Miss Molly, Little Richard"
			});
			songs.Add(new Song()
			{
				Title = "Blue Suede Shoes",
				Author = "Carl Perkins"
			});
			songs.Add(new Song()
			{
				Title = "Great Balls of Fire",
				Author = "Jerry Lee Lewis"
			});
			songs.Add(new Song()
			{
				Title = "Roll Over Beethoven",
				Author = "Chuck Berry"
			});
			songs.Add(new Song()
			{
				Title = "Love and Happiness",
				Author = "Al Green"
			});
			songs.Add(new Song()
			{
				Title = "Fortunate Son",
				Author = "Creedence Clearwater Revival"
			});
			songs.Add(new Song()
			{
				Title = "You Can't Always Get What You Want",
				Author = "The Rolling Stones"
			});
			songs.Add(new Song()
			{
				Title = "Voodoo Child (Slight Return)",
				Author = "Jimi Hendrix"
			});
			songs.Add(new Song()
			{
				Title = "Be-Bop-A-Lula",
				Author = "Gene Vincent and His Blue Caps"
			});
			songs.Add(new Song()
			{
				Title = "Hot Stuff",
				Author = "Donna Summer"
			});
			songs.Add(new Song()
			{
				Title = "Living for the City",
				Author = "Stevie Wonder"
			});
			songs.Add(new Song()
			{
				Title = "The Boxer",
				Author = "Simon and Garfunkel"
			});
			songs.Add(new Song()
			{
				Title = "Mr. Tambourine Man",
				Author = "Bob Dylan"
			});
			songs.Add(new Song()
			{
				Title = "Not Fade Away",
				Author = "Buddy Holly and the Cricket"
			});
			songs.Add(new Song()
			{
				Title = "Little Red Corvette",
				Author = "Prince"
			});
			songs.Add(new Song()
			{
				Title = "In The End",
				Author = "Linkin Park"
			});
			songs.Add(new Song()
			{
				Title = "Bohemian Rhapsody",
				Author = "Queen"
			});
			songs.Add(new Song()
			{
				Title = "Enter Sandman",
				Author = "Metallica"
			});
			songs.Add(new Song()
			{
				Title = "Nothing Else Matters",
				Author = "Metallica"
			});
			songs.Add(new Song()
			{
				Title = "California Love",
				Author = "Dr. Dre and 2Pac"
			});
			songs.Add(new Song()
			{
				Title = "Dancing Queen",
				Author = "Abba"
			});
        }

        public ObservableCollection<Song> GetSongs()
        {
            songs.Clear();
            EntrySongsData();
            return this.songs;
        }
        #endregion

        #region Movies manipulation
        public void EntryMoviesData()
        {
            movies.Add(new Movie()
            {
                MovieTitle = "The Godfather"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "Scarface"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "Goodfellas"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "The Godfather: Part II"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "Pulp Fiction"
            });

            movies.Add(new Movie()
            {
                MovieTitle = "Il buono, il brutto, il cattivo."
            });
            movies.Add(new Movie()
            {
                MovieTitle = "12 Angry Men"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "Schindler's List"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "The Dark Knight"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "One Flew Over the Cuckoo's Nest"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "Star Wars: Episode V - The Empire Strikes Back"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "Fight Club"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "Shichinin no samurai"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "Inception"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "Goodfellas"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "Star Wars"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "Cidade de Deus"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "The Matrix"
            });

            movies.Add(new Movie()
            {
                MovieTitle = "Casablanca"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "C'era una volta il West"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "The Lord of the Rings: The Two Towers"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "The Silence of the Lambs"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "Forrest Gump"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "Se7en"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "The Usual Suspects"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "Memento"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "Apocalypse Now"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "Saving Private Ryan"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "Vertigo"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "The Shining"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "Taxi Driver"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "Gladiator"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "L.A. Confidential"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "Once Upon a Time in America"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "Braveheart"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "Unforgiven"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "Die Hard"
            });
            movies.Add(new Movie()
            {
                MovieTitle = "Snatch."
            });
            movies.Add(new Movie()
            {
                MovieTitle = "A Beautiful Mind"
            });
			movies.Add(new Movie()
			{
				MovieTitle = "Jaws"
			});
			movies.Add(new Movie()
			{
				MovieTitle = "Requiem for a Dream"
			});
			movies.Add(new Movie()
			{
				MovieTitle = "Dazed and Confused"
			});
        }

        public ObservableCollection<Movie> GetMovies()
        {
            movies.Clear();
            EntryMoviesData();
            return this.movies;
        }

        #endregion

        #region Food Places manipulation
        public void EntryFoodPlacesData()
        {
            foodPlaces.Add(new FoodPlace()
            {
                Name = "A Tavola",
                IconBackground = "#FFFF6900",
                IconPath = new Uri("../Images/FirstLook/ladle.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "Area Five",
                IconBackground = "#FFFFDE00",
                IconPath = new Uri("../Images/FirstLook/cup.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "Anna's Kitchen",
                IconBackground = "#FF8EBC00",
                IconPath = new Uri("../Images/FirstLook/cheese.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "American Dreams",
                IconBackground = "#FF16ABA9",
                IconPath = new Uri("../Images/FirstLook/birthday_cake.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "O'Paris",
                IconBackground = "#FF8EBC00",
                IconPath = new Uri("../Images/FirstLook/cheese.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "Suppateria",
                IconBackground = "#FFFF6900",
                IconPath = new Uri("../Images/FirstLook/ladle.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "Memento",
                IconBackground = "#FFFFDE00",
                IconPath = new Uri("../Images/FirstLook/cup.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "Benny's cakes",
                IconBackground = "#FF16ABA9",
                IconPath = new Uri("../Images/FirstLook/birthday_cake.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "Noah's kitchen",
                IconBackground = "#FFCC3366",
                IconPath = new Uri("../Images/FirstLook/tools.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "Franko's",
                IconBackground = "#FFCC9933",
                IconPath = new Uri("../Images/FirstLook/cooking_pot.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "Shobu Sake House",
                IconBackground = "#FFFFDE00",
                IconPath = new Uri("../Images/FirstLook/cup.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "Table 10",
                IconBackground = "#FF16ABA9",
                IconPath = new Uri("../Images/FirstLook/birthday_cake.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "Verandah",
                IconBackground = "#FFCC3366",
                IconPath = new Uri("../Images/FirstLook/tools.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "Wing Lei",
                IconBackground = "#FFCC9933",
                IconPath = new Uri("../Images/FirstLook/cooking_pot.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "25 Lusk",
                IconBackground = "#FFFFDE00",
                IconPath = new Uri("../Images/FirstLook/cup.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "Abe & Arthur’s",
                IconBackground = "#FF16ABA9",
                IconPath = new Uri("../Images/FirstLook/birthday_cake.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "Asellina Ristorante",
                IconBackground = "#FFCC3366",
                IconPath = new Uri("../Images/FirstLook/tools.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "B.B. King’s Blues Club",
                IconBackground = "#FFCC9933",
                IconPath = new Uri("../Images/FirstLook/cooking_pot.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "Beaumarchais",
                IconBackground = "#FFCC9933",
                IconPath = new Uri("../Images/FirstLook/cooking_pot.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "Chino Latino",
                IconBackground = "#FFFFDE00",
                IconPath = new Uri("../Images/FirstLook/cup.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "Fig & Olive",
                IconBackground = "#FF16ABA9",
                IconPath = new Uri("../Images/FirstLook/birthday_cake.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "HUB 51",
                IconBackground = "#FFCC3366",
                IconPath = new Uri("../Images/FirstLook/tools.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "Lavo",
                IconBackground = "#FFCC9933",
                IconPath = new Uri("../Images/FirstLook/cooking_pot.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "Linger",
                IconBackground = "#FF16ABA9",
                IconPath = new Uri("../Images/FirstLook/birthday_cake.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "Lost Society",
                IconBackground = "#FFCC3366",
                IconPath = new Uri("../Images/FirstLook/tools.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "Mercato di Vetro",
                IconBackground = "#FFCC9933",
                IconPath = new Uri("../Images/FirstLook/cooking_pot.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "N9NE Steakhouse",
                IconBackground = "#FFFFDE00",
                IconPath = new Uri("../Images/FirstLook/cup.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "Nada",
                IconBackground = "#FF16ABA9",
                IconPath = new Uri("../Images/FirstLook/birthday_cake.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "Nisen",
                IconBackground = "#FFCC3366",
                IconPath = new Uri("../Images/FirstLook/tools.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "Nobu Miami",
                IconBackground = "#FFCC9933",
                IconPath = new Uri("../Images/FirstLook/cooking_pot.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "Prato",
                IconBackground = "#FF16ABA9",
                IconPath = new Uri("../Images/FirstLook/birthday_cake.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "Roka Akor",
                IconBackground = "#FFCC3366",
                IconPath = new Uri("../Images/FirstLook/tools.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "The Stanton Social",
                IconBackground = "#FFCC9933",
                IconPath = new Uri("../Images/FirstLook/cooking_pot.png", UriKind.RelativeOrAbsolute)
            });
            foodPlaces.Add(new FoodPlace()
            {
                Name = "Geisha House",
                IconBackground = "#FFCC9933",
                IconPath = new Uri("../Images/FirstLook/cooking_pot.png", UriKind.RelativeOrAbsolute)
            });
			foodPlaces.Add(new FoodPlace()
			{
				Name = "Acquerello",
				IconBackground = "#FF16ABA9",
				IconPath = new Uri("../Images/FirstLook/birthday_cake.png", UriKind.RelativeOrAbsolute)
			});
			foodPlaces.Add(new FoodPlace()
			{
				Name = "Aziza",
				IconBackground = "#FFCC9933",
				IconPath = new Uri("../Images/FirstLook/cooking_pot.png", UriKind.RelativeOrAbsolute)
			});
			foodPlaces.Add(new FoodPlace()
			{
				Name = "A & J",
				IconBackground = "#FFCC3366",
				IconPath = new Uri("../Images/FirstLook/tools.png", UriKind.RelativeOrAbsolute)
			});
			foodPlaces.Add(new FoodPlace()
			{
				Name = "X & Bully Boy Bar",
				IconBackground = "#FFCC3366",
				IconPath = new Uri("../Images/FirstLook/tools.png", UriKind.RelativeOrAbsolute)
			});
        }

        public ObservableCollection<FoodPlace> GetFoodPlaces()
        {
            foodPlaces.Clear();
            EntryFoodPlacesData();
            return this.foodPlaces;
        }

        #endregion
    }
}

import os
import glob
import hdf5_getters
import csv


class SongInfo:
    song_id = 1
    album_name_limit = 48
    title_limit = 98

    def __init__(self):
        self.song_id = 0
        self.title = 0
        self.album_name = 0
        self.artist_id = 0


class SongAnalysis:

    def __init__(self):
        self.song_id = 0
        self.song_hotness = 0.0
        self.tempo = 0.0
        self.duration = 0.0
        self.loudness = 0.0


class Artist:
    artist_id = 1
    is_artist_writable = True
    db_name_limit = 98
    db_genre_limit = 48
    artist_id_dict = {}  # (million song db id, our id)
    similar_artists_dict = {}  # (artist id, similar_artist_list)

    def __init__(self):
        self.artist_id = 0
        self.artist_name = 0
        self.genre = 0
        self.artist_hotness = 0.0


def generate_song_info_from_file(h5_file):
    song_info = SongInfo()
    # song_info.song_id = hdf5_getters.get_song_id(h5_file)
    song_info.title = hdf5_getters.get_title(h5_file)
    song_info.album_name = hdf5_getters.get_release(h5_file)
    is_song_info_len_invalid = len(str(song_info.title)) > SongInfo.title_limit or len(
        str(song_info.album_name)) > SongInfo.album_name_limit
    # song_info.artist_id = hdf5_getters.get_artist_id(h5_file)
    return song_info, is_song_info_len_invalid


def generate_song_analysis_from_file(h5_file):
    song_analysis = SongAnalysis()
    # song_analysis.song_id = hdf5_getters.get_song_id(h5_file)
    song_analysis.song_hotness = hdf5_getters.get_song_hotttnesss(h5_file)
    if str(song_analysis.song_hotness) == 'nan':
        # TODO: NULL?
        song_analysis.song_hotness = 0.0
    else:
        song_analysis.song_hotness = round(song_analysis.song_hotness, 5)  # round to fit SQL
    song_analysis.tempo = hdf5_getters.get_tempo(h5_file)
    song_analysis.duration = hdf5_getters.get_duration(h5_file)
    song_analysis.loudness = hdf5_getters.get_loudness(h5_file)
    return song_analysis


def generate_artist_from_file(h5_file):
    artist = Artist()
    artist.artist_id = hdf5_getters.get_artist_id(h5_file)
    artist.artist_name = hdf5_getters.get_artist_name(h5_file)
    genres = hdf5_getters.get_artist_terms(h5_file)
    if len(genres) > 0:
        artist.genre = genres[0]
    else:
        artist.genre = None
    is_artist_len_invalid = len(str(artist.artist_name)) > Artist.db_name_limit or len(
        str(artist.genre)) > Artist.db_genre_limit

    # artist id
    if artist.artist_id in Artist.artist_id_dict:
        print 'found duplicate ' + str(artist.artist_name) + ' with id ' + str(Artist.artist_id_dict[artist.artist_id])
        artist.artist_id = Artist.artist_id_dict[artist.artist_id]  # add exiting id
        Artist.is_artist_writable = False
    else:
        Artist.is_artist_writable = True
        Artist.artist_id_dict[artist.artist_id] = Artist.artist_id  # add (million song db id, our id)
        artist.artist_id = Artist.artist_id
        Artist.artist_id += 1
        similar_artists_list = hdf5_getters.get_similar_artists(h5_file)
        Artist.similar_artists_dict[
            artist.artist_id] = similar_artists_list  # add similar artist list to (id, similar_artist) dict

    artist.artist_hotness = hdf5_getters.get_artist_hotttnesss(h5_file)
    return artist, is_artist_len_invalid


# generate csv writers
song_info_csv = open('song_info.csv', 'wb')
song_info_writer = csv.writer(song_info_csv, delimiter=',', quotechar='"', quoting=csv.QUOTE_MINIMAL)
song_analysis_csv = open('song_analysis.csv', 'wb')
song_analysis_writer = csv.writer(song_analysis_csv, delimiter=',', quotechar='"', quoting=csv.QUOTE_MINIMAL)
artists_csv = open('artists.csv', 'wb')
artists_writer = csv.writer(artists_csv, delimiter=',', quotechar='"', quoting=csv.QUOTE_MINIMAL)
similar_artists_csv = open('similar_artists.csv', 'wb')

# write first row
song_info_writer.writerow(['song_id', 'title', 'album_name', 'artist_id'])
song_analysis_writer.writerow(['song_id', 'song_hotness', 'tempo', 'duration', 'loudness'])
artists_writer.writerow(['artist_id', 'artist_name', 'genre', 'artist_hotness'])

# generate data from h5 files
# TODO: Similar Artists
basedir = "C:\Users\Dan\Desktop\University\DB Workshop\MillionSongSubset\data"  # TODO: hardcoded as fuck
ext = ".h5"
for root, dirs, files in os.walk(basedir):
    fs = glob.glob(os.path.join(root, '*' + ext))
    for f in fs:
        songH5File = hdf5_getters.open_h5_file_read(f)
        song_info, is_song_info_len_invalid = generate_song_info_from_file(songH5File)
        song_analysis = generate_song_analysis_from_file(songH5File)
        artist, is_artist_len_invalid = generate_artist_from_file(songH5File)

        # length checks

        if is_artist_len_invalid or is_song_info_len_invalid:
            # length is invalid
            songH5File.close()
            continue

        # ids
        song_info.song_id = SongInfo.song_id
        song_info.artist_id = artist.artist_id
        song_analysis.song_id = SongInfo.song_id
        SongInfo.song_id += 1

        # rows
        song_info_row = [song_info.song_id, song_info.title, song_info.album_name, song_info.artist_id]
        song_analysis_row = [song_analysis.song_id, song_analysis.song_hotness, song_analysis.tempo,
                             song_analysis.duration, song_analysis.loudness]

        # write rows to file
        if Artist.is_artist_writable:
            artist_row = [artist.artist_id, artist.artist_name, artist.genre, artist.artist_hotness]
            artists_writer.writerow(artist_row)

        song_info_writer.writerow(song_info_row)
        song_analysis_writer.writerow(song_analysis_row)

        songH5File.close()

similar_artists_writer = csv.writer(similar_artists_csv, delimiter=',', quotechar='"', quoting=csv.QUOTE_MINIMAL)
similar_artists_writer.writerow(['artist_id', 'similar_to_artist_id'])
for mdb_id, artist_id_to_write in Artist.artist_id_dict.iteritems():
    similar_artist_list = Artist.similar_artists_dict[artist_id_to_write]
    for similar_artist_id in similar_artist_list:
        similar_artist_id_to_write = Artist.artist_id_dict.get(similar_artist_id)
        if similar_artist_id_to_write is not None:
            similar_artists_writer.writerow([artist_id_to_write, similar_artist_id_to_write])
song_info_csv.close()
song_analysis_csv.close()
artists_csv.close()
similar_artists_csv.close()

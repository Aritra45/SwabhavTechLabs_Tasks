import 'package:hive/hive.dart';

class LoadUserName{

  String userName;

  LoadUserName({this.userName = ''});

  Future<void> loadLoggedInUserName() async {
    final userBox = await Hive.openBox('users');

    final loggedEmail = await userBox.get('loggedUser');

    if (loggedEmail != null) {
      final userData = await userBox.get(loggedEmail);

      if (userData != null && userData is Map) {
        userName = userData['name'];
      }
    }
  }
}
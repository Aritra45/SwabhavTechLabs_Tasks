import 'package:flutter/material.dart';
import 'package:world_time/services/world_time.dart';
import 'package:logo_n_spinner/logo_n_spinner.dart';


class Loading extends StatefulWidget {
  @override
  State<Loading> createState() => _LoadingState();
}

class _LoadingState extends State<Loading> {

  void setupWorldTime() async {
    WorldTime tik = WorldTime();
    await tik.getTime();
    Navigator.pushNamed(context, '/home', arguments: {'title': tik.text, 'time': tik.time, 'isDayTime':tik.isDayTime});
  }

  @override
  void initState() {
    super.initState();
    setupWorldTime();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        child: Center(
          child: LogoandSpinner(
            imageAssets: 'assets/loading.png',
            reverse: true,
            arcColor: Colors.blue,
            spinSpeed: Duration(milliseconds: 500),
          ),
        ),
      ),
    );
  }
}

import 'package:flutter/material.dart';
import 'info.dart';

class cardDetails extends StatelessWidget {
  final Info infos;
  final VoidCallback deleteCard;
  cardDetails(this.infos, {required this.deleteCard});

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.only(right: 10),
      child: Card(
        child: Column(
          children: [
            Padding(
              padding: EdgeInsets.fromLTRB(16, 0, 16, 0),
              child: Text(
                infos.text,
                style: TextStyle(fontSize: 15, color: Colors.amber[800]),
              ),
            ),
            TextButton.icon(
              onPressed:deleteCard, 
            label: Text('Delete', style: TextStyle(color: Colors.red[800]),),
            icon: Icon(Icons.delete, color: Colors.red[800],),),
          ],
        ),
        color: Colors.grey[300],
      ),
    );
  }
}

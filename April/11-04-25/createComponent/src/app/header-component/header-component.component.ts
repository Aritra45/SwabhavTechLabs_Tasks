import { Component, EventEmitter, Input, input, Output } from '@angular/core';


@Component({
  selector: 'app-header-component',
  standalone: false,
  templateUrl: './header-component.component.html',
  styleUrl: './header-component.component.css'
})
export class HeaderComponentComponent {
  @Input() title = ''

  @Output()
  sendIdtoParent: EventEmitter<any>=new EventEmitter<any>()
  id = 7
  sendEmmited(){
    this.sendIdtoParent.emit(this.id)
  }
}

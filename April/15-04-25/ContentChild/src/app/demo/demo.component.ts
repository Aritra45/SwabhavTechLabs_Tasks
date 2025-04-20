import { Component, ContentChild, ElementRef } from '@angular/core';

@Component({
  selector: 'app-demo',
  standalone: false,
  templateUrl: './demo.component.html',
  styleUrl: './demo.component.css'
})
export class DemoComponent {
  showdata : any
  result1:any
  @ContentChild('refh1')
  data!: ElementRef
  
  ngOnInit(){
    this.result1 = 20
    this.showdata=this.data.nativeElement.value
    
  }

  ngAfterContentInit(){
    this.showdata=this.data.nativeElement.textContent
  }
}

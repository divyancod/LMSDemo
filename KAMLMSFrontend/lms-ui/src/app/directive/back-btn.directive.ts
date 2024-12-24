import { Directive, HostListener } from '@angular/core';
import { BackNavigationService } from '../service/back-navigation.service';

@Directive({
  selector: '[appBackBtn]'
})
export class BackBtnDirective {

  constructor(private navigationService:BackNavigationService) { }

  @HostListener('click')
  onClick():void{
    this.navigationService.back()
  }
}

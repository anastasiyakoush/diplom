import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.less']
})
export class HeaderComponent implements OnInit {
  group: number;

  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.group = +params['groupId'];
    });
  }

  navigateToDiscipline() {
    if (this.group) {
      this.router.navigate(['/support/' + this.group + '/disciplines']);
    } else {
      this.router.navigateByUrl('/groups');
    }

  }
}

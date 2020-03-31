import { Component, OnInit, Input, Output, EventEmitter, OnDestroy } from '@angular/core';
import { Store } from '@ngrx/store';
import { save, closeDialogNew } from '../../../store/members/members-actions';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Site } from '../../../model/site/site';
import { Member } from '../../../model/user/member';
import { AppState } from 'src/app/shared/bia-shared/store/state';
import { Subscription } from 'rxjs';
import { getDisplayNewDialog } from '../../../store/members/member.state';
import { Role } from 'src/app/domains/member-role/model/role';
import { User } from 'src/app/domains/user/model/user';
import { getAllRoles } from 'src/app/domains/member-role/store/member-role.state';
import { getAllUsers } from 'src/app/domains/user/store/user.state';
import { loadAllByFilter } from 'src/app/domains/user/store/users-actions';

@Component({
  selector: 'app-member-new-dialog',
  templateUrl: './member-new-dialog.component.html',
  styleUrls: ['./member-new-dialog.component.scss']
})
export class MemberNewDialogComponent implements OnInit, OnDestroy {
  display = false;
  private sub = new Subscription();
  @Output() displayChange = new EventEmitter<boolean>();

  @Input() site: Site;
  allRoles$: Observable<Role[]>;
  users$: Observable<User[]>;

  constructor(private store: Store<AppState>) {}

  ngOnInit() {
    this.allRoles$ = this.store.select(getAllRoles).pipe();
    this.users$ = this.store
      .select(getAllUsers)
      .pipe()
      .pipe(
        map((users: User[]) => {
          users.forEach((user: User) => {
            user.displayName = `${user.firstName} ${user.lastName} (${user.login})`;
          });
          return users;
        })
      );
    this.sub.add(
      this.store
        .select(getDisplayNewDialog)
        .pipe()
        .subscribe((x) => (this.display = x))
    );
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  onSubmitted(memberToCreates: Member[]) {
    this.store.dispatch(save({ members: memberToCreates }));
    this.close();
  }

  onCancelled() {
    this.close();
  }

  public close() {
    this.store.dispatch(closeDialogNew());
  }

  onSearchUsers(value: string) {
    this.store.dispatch(loadAllByFilter({ filter: value }));
  }
}

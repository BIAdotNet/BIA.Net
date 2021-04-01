import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map, pluck, switchMap } from 'rxjs/operators';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import {
  failure,
  load,
  loadAllSites,
  loadAllSuccess,
  loadSuccess,
  setDefaultSite
} from './sites-actions';
import { BiaMessageService } from 'src/app/core/bia-core/services/bia-message.service';
import { SiteDas } from '../services/site-das.service';
import { MemberDas } from '../services/member-das.service';

/**
 * Effects file is for isolating and managing side effects of the application in one place
 * Http requests, Sockets, Routing, LocalStorage, etc
 */

@Injectable()
export class SitesEffects {
  loadAll$ = createEffect(() =>
    this.actions$.pipe(
      ofType(loadAllSites) /* When action is dispatched */,
      /* startWith(loadAll()), */
      /* Hit the Sites Index endpoint of our REST API */
      /* Dispatch LoadAllSuccess action to the central store with id list returned by the backend as id*/
      /* 'Sites Reducers' will take care of the rest */
      switchMap(() =>
        this.siteDas.getList().pipe(
          map((sites) => loadAllSuccess({ sites })),
          catchError((err) => {
            this.biaMessageService.showError();
            return of(failure({ error: err }));
          })
        )
      )
    )
  );

  load$ = createEffect(() =>
    this.actions$.pipe(
      ofType(load),
      pluck('id'),
      switchMap((id) =>
        this.siteDas.get(id).pipe(
          map((site) => loadSuccess({ site })),
          catchError((err) => {
            this.biaMessageService.showError();
            return of(failure({ error: err }));
          })
        )
      )
    )
  );

  setDefaultSite$ = createEffect(() =>
    this.actions$.pipe(
      ofType(setDefaultSite),
      pluck('id'),
      switchMap((id) =>
        this.memberDas.setDefaultSite(id).pipe(
          map((x) => {
            this.biaMessageService.showUpdateSuccess();
            return loadAllSites();
          })
        )
      )
    )
  );

  constructor(
    private actions$: Actions,
    private siteDas: SiteDas,
    private memberDas: MemberDas,
    private biaMessageService: BiaMessageService
  ) {}
}
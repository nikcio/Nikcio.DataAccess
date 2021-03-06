# Changelog

All notable changes to this project will be documented in this file. See [standard-version](https://github.com/conventional-changelog/standard-version) for commit guidelines.

## [3.0.0](https://github.com/nikcio/Nikcio.DataAccess/compare/v2.0.3...v3.0.0) (2022-04-16)


### ⚠ BREAKING CHANGES

* Changed extension call signature
* Changed CrudServiceBase constructor signature
* Changed call signature on RemoveFromCollection and AddToCollection
* Changed call signature of DbCrudRepositoryBase

### Features

* Added CloseUnitOfWorkAsync ([06ea7cb](https://github.com/nikcio/Nikcio.DataAccess/commit/06ea7cb77b228f7cbf9fe480bb04fbd281af083d))
* Added modifiers to enable extensibility ([b1253fa](https://github.com/nikcio/Nikcio.DataAccess/commit/b1253faefce000b8fd7e47d7fe0c83fd76e40d18))
* Added option classes for extensions ([053e8fc](https://github.com/nikcio/Nikcio.DataAccess/commit/053e8fc6a35bfdee3e9a5363edf9da2f2aacf0e4))
* Added Unit of work services ([c44976f](https://github.com/nikcio/Nikcio.DataAccess/commit/c44976f18f1cc4b6415f978018e0908cf26b2572))
* Decoupled service base and unit of work ([dda64b1](https://github.com/nikcio/Nikcio.DataAccess/commit/dda64b157d0bc0889db91671c659bccb993842e5))
* Updated dbcontext creation logic ([ad9d135](https://github.com/nikcio/Nikcio.DataAccess/commit/ad9d1356bf4f87948872a19fe09a8bf07381418e))
* Updated exceptions to include more information ([68271cc](https://github.com/nikcio/Nikcio.DataAccess/commit/68271cca7e019d09b044600d46fb9e59906a29f4))


### Bug Fixes

* Added check for transaction is null ([aa762b0](https://github.com/nikcio/Nikcio.DataAccess/commit/aa762b05652430bac4c0a80982d2e421fe73781c))
* Dispose transaction on commit ([f839281](https://github.com/nikcio/Nikcio.DataAccess/commit/f83928195a23c1124e2bb2e47304f848f32d189b))
* Fixed collections not loaded on AddToCollection and RemoveFromCollection leading to strange behaviour ([e1850e5](https://github.com/nikcio/Nikcio.DataAccess/commit/e1850e520bd32ff45ed3a473f9a4537b05096654))
* Fixed Unit of work using wrong DbContext ([01380d6](https://github.com/nikcio/Nikcio.DataAccess/commit/01380d671e78a3be33992de3b34535413e120e2b))

### [2.0.3](https://github.com/nikcio/Nikcio.DataAccess/compare/v2.0.2...v2.0.3) (2022-04-09)


### Bug Fixes

* Added configureAwait to async methods ([523f1a5](https://github.com/nikcio/Nikcio.DataAccess/commit/523f1a5bbf42246ad790352a5d16f0ffb029d834))
* Fixed dbcontext disposed in some cases ([42ffa5a](https://github.com/nikcio/Nikcio.DataAccess/commit/42ffa5ab06b5610eaa29729d8de5c713a7ed14bb))
* Fixed relation data would be reset ([9368ce9](https://github.com/nikcio/Nikcio.DataAccess/commit/9368ce90e146916af3e816899d9213462da6844a))
* Fixed spelling error Reponse --> Response ([4d1ee34](https://github.com/nikcio/Nikcio.DataAccess/commit/4d1ee34658e38b49276520b6e7de934ad447900b))

### [2.0.2](https://github.com/nikcio/Nikcio.DataAccess/compare/v2.0.1...v2.0.2) (2022-03-01)


### Bug Fixes

* Fixed typos ([8fb0748](https://github.com/nikcio/Nikcio.DataAccess/commit/8fb07482fc4dc3bcdc81aef574e10314a885c9d9))

## [2.0.1](https://github.com/nikcio/Nikcio.DataAccess/compare/v2.0.0...v2.2.0) (2022-02-26)


### Bug Fixes

* Fixed settings not being read ([005c2e4](https://github.com/nikcio/Nikcio.DataAccess/commit/005c2e4685bb0ef95734c8b2ed414bf0a043febe))

## [2.0.0](https://github.com/nikcio/Nikcio.DataAccess/compare/v1.2.0...v2.0.0) (2022-02-26)


### ⚠ BREAKING CHANGES

* No longer supports .Net 5. Upgrade to .Net 6

### Features

* .Net 6 & nullable support ([16a02ac](https://github.com/nikcio/Nikcio.DataAccess/commit/16a02ac3d41d2c788c3b68d8071438c33a1b30c6))
* Bumped EF Core dependency ([b30c7e7](https://github.com/nikcio/Nikcio.DataAccess/commit/b30c7e71ab6a2b259833de32de029637f2f662d1))

## [1.2.0](https://github.com/nikcio/Nikcio.DataAccess/compare/v1.0.0...v1.2.0) (2022-02-26)


### Features

* Added settings for default isolation level ([b42e918](https://github.com/nikcio/Nikcio.DataAccess/commit/b42e91885d9c00bcf1bf880e6f40c7cbc2f076f3))
* Changed visibility of constructors ([6eb0cca](https://github.com/nikcio/Nikcio.DataAccess/commit/6eb0cca96cb99c731bbfb91a29df9632abc1bf72))


### Bug Fixes

* Fixed datasettings not included in constructor ([7597c5f](https://github.com/nikcio/Nikcio.DataAccess/commit/7597c5f11e067d18e78b34eb01d75ede8ce387f1))

## [1.1.0](https://github.com/nikcio/Nikcio.DataAccess/compare/v1.0.0...v1.1.0) (2022-02-26)


### Features

* Added settings for default isolation level ([b42e918](https://github.com/nikcio/Nikcio.DataAccess/commit/b42e91885d9c00bcf1bf880e6f40c7cbc2f076f3))
* Changed visibility of constructors ([6eb0cca](https://github.com/nikcio/Nikcio.DataAccess/commit/6eb0cca96cb99c731bbfb91a29df9632abc1bf72))

## 1.0.0 (2022-02-18)


### Features

* Added docs and final touches ([230edb7](https://github.com/nikcio/Nikcio.DataAccess/commit/230edb75e22c1f6fbf59f72f79af051647e0da95))
* Added files ([71be07e](https://github.com/nikcio/Nikcio.DataAccess/commit/71be07e5e8869df590b894e5a4a177fede32a5d9))
* Added release.bat ([72458c3](https://github.com/nikcio/Nikcio.DataAccess/commit/72458c31da323db823c5084c9bcf0cecc73283e8))

import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { Parts } from '../Model/Parts';
import { PartsFilter } from '../Model/PartsFilter';
import { CompatiblePartsService } from './compatibleParts.service';


describe('CompatiblePartsService', () => {
  let service: CompatiblePartsService;
  let value:string;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]

    });
    service = TestBed.inject(CompatiblePartsService);

  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });


  it('Should split Split whith full Part Number', ()=> {
    value="1234-aBcD123";

    service.SplitPartNumber(value);

    expect(service.compatibleItem.PartId).toEqual("1234");
    expect(service.compatibleItem.PartCode).toEqual("aBcD123");
  });

  it('Should split Split whith PartId', ()=> {
    value="1234";

    service.SplitPartNumber(value);

    expect(service.compatibleItem.PartId).toEqual("1234");
  });

  it('Should split Split whith PartCode', ()=> {
    value="aBcD123";

    service.SplitPartNumber(value);

    expect(service.compatibleItem.PartCode).toEqual("aBcD123");
  });


  
});

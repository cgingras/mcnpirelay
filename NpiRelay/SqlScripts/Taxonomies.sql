CREATE TABLE [dbo].[Taxonomy]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[Code] NVARCHAR(100) NOT NULL, 
	[Description] NVARCHAR(500) NULL,
	CONSTRAINT [PK_Taxonomy_Id] PRIMARY KEY ([Id] ASC),
	CONSTRAINT [UX_Taxonomy_Code] UNIQUE ([Code])
)

INSERT INTO Taxonomy
([Code],[Description])
VALUES
 ('208D00000X', 'Allopathic & Osteopathic Physicians/General Practice')
,('208600000X', 'Allopathic & Osteopathic Physicians/Surgery')
,('2086H0002X', 'Allopathic & Osteopathic Physicians/Surgery/Hospice and Palliative Medicine')
,('2086S0120X', 'Allopathic & Osteopathic Physicians/Surgery/Pediatric Surgery')
,('2086S0122X', 'Allopathic & Osteopathic Physicians/Surgery/Plastic and Reconstructive Surgery')
,('2086S0105X', 'Allopathic & Osteopathic Physicians/Surgery/Surgery of the Hand')
,('2086S0102X', 'Allopathic & Osteopathic Physicians/Surgery/Surgical Critical Care')
,('2086X0206X', 'Allopathic & Osteopathic Physicians/Surgery/Surgical Oncology')
,('2086S0127X', 'Allopathic & Osteopathic Physicians/Surgery/Trauma Surgery')
,('2086S0129X', 'Allopathic & Osteopathic Physicians/Surgery/Vascular Surgery')
,('208G00000X', 'Allopathic & Osteopathic Physicians/Thoracic Surgery (Cardiothoracic Vascular Surgery)')
,('204F00000X', 'Allopathic & Osteopathic Physicians/Transplant Surgery')
,('208C00000X', 'Allopathic & Osteopathic Physicians/Colon & Rectal Surgery')
,('207T00000X', 'Allopathic & Osteopathic Physicians/Neurological Surgery')
,('204E00000X', 'Allopathic & Osteopathic Physicians/Oral & Maxillofacial Surgery')
,('207X00000X', 'Allopathic & Osteopathic Physicians/Orthopaedic Surgery')
,('207XS0114X', 'Allopathic & Osteopathic Physicians/Orthopaedic Surgery/Adult Reconstructive Orthopaedic Surgery')
,('207XX0004X', 'Allopathic & Osteopathic Physicians/Orthopaedic Surgery/Foot and Ankle Surgery')
,('207XS0106X', 'Allopathic & Osteopathic Physicians/Orthopaedic Surgery/Hand Surgery')
,('207XS0117X', 'Allopathic & Osteopathic Physicians/Orthopaedic Surgery/Orthopaedic Surgery of the Spine')
,('207XX0801X', 'Allopathic & Osteopathic Physicians/Orthopaedic Surgery/Orthopaedic Trauma')
,('207XP3100X', 'Allopathic & Osteopathic Physicians/Orthopaedic Surgery/Pediatric Orthopaedic Surgery')
,('207XX0005X', 'Allopathic & Osteopathic Physicians/Orthopaedic Surgery/Sports Medicine')
,('208200000X', 'Allopathic & Osteopathic Physicians/Plastic Surgery')
,('2082S0099X', 'Allopathic & Osteopathic Physicians/Plastic Surgery/Plastic Surgery Within the Head & Neck')
,('2082S0105X', 'Allopathic & Osteopathic Physicians/Plastic Surgery/Surgery of the Hand')
,('207K00000X', 'Allopathic & Osteopathic Physicians/Allergy and Immunology')
,('207KA0200X', 'Allopathic & Osteopathic Physicians/Allergy and Immunology/Allergy')
,('207KI0005X', 'Allopathic & Osteopathic Physicians/Allergy and Immunology/Clinical & Laboratory Immunology')
,('207Y00000X', 'Allopathic & Osteopathic Physicians/ Otolaryngology')
,('207YS0123X', 'Allopathic & Osteopathic Physicians/ Otolaryngology/Facial Plastic Surgery')
,('207YX0602X', 'Allopathic & Osteopathic Physicians/Otolaryngology/Otolaryngic Allergy')
,('207YX0905X', 'Allopathic & Osteopathic Physicians/Otolaryngology/Otolaryngology/Facial Plastic Surgery')
,('207YX0901X', 'Allopathic & Osteopathic Physicians/Otolaryngology/Otology &Neurotology')
,('207YP0228X', 'Allopathic & Osteopathic Physicians/Otolaryngology/Pediatric Otolaryngology')
,('207YX0007X', 'Allopathic & Osteopathic Physicians/Otolaryngology/Plastic Surgery within the Head & Neck')
,('207YS0012X', 'Allopathic & Osteopathic Physicians/Otolaryngology/Sleep Medicine')
,('207L00000X', 'Allopathic & Osteopathic Physicians/Anesthesiology')
,('207LA0401X', 'Allopathic & Osteopathic Physicians/Anesthesiology/Addiction Medicine')
,('207LC0200X', 'Allopathic & Osteopathic Physicians/Anesthesiology/Critical Care Medicine')
,('207LH0002X', 'Allopathic & Osteopathic Physicians/Anesthesiology/Hospice and Palliative Medicine')
,('207LP2900X', 'Allopathic & Osteopathic Physicians/Anesthesiology/Pain Medicine')
,('207LP3000X', 'Allopathic & Osteopathic Physicians/Anesthesiology/Pediatric Anesthesiology')
,('207RC0000X', 'Allopathic & Osteopathic Physicians/Internal Medicine, Cardiovascular Disease')
,('207N00000X', 'Allopathic & Osteopathic Physicians/Dermatology')
,('207NI0002X', 'Allopathic & Osteopathic Physicians/Dermatology, Clinical & Laboratory Dermatological Immunology')
,('207ND0101X', 'Allopathic & Osteopathic Physicians/Dermatology, MOHS-Micrographic Surgery')
,('207ND0900X', 'Allopathic & Osteopathic Physicians/Dermatology, Dermapathology')
,('207NP0225X', 'Allopathic & Osteopathic Physicians/Dermatology, Pediatric Dermatology')
,('207NS0135X', 'Allopathic &Osteopathic Physicians/Dermatology, Procedural Dermatology')
,('207Q00000X', 'Allopathic & Osteopathic Physicians/Family Medicine')
,('207QA0401X', 'Allopathic & Osteopathic Physicians/Family Medicine, Addiction Medicine')
,('207QA0000X', 'Allopathic & Osteopathic Physicians/Family Medicine, Adolescent Medicine')
,('207QA0505X', 'Allopathic & Osteopathic Physicians/Family Medicine, Adult Medicine')
,('207QB0002X', 'Allopathic & Osteopathic Physicians/Family Medicine, Bariatric Medicine')
,('207QG0300X', 'Allopathic & Osteopathic Physicians/Family Medicine, Geriatric Medicine')
,('207QH0002X', 'Allopathic & Osteopathic Physicians/Family Medicine, Hospice and Palliative Medicine')
,('207QS0010X', 'Allopathic & Osteopathic Physicians/Family Medicine, Sports Medicine')
,('207QS1201X', 'Allopathic & Osteopathic Physicians/Family Medicine, Sleep Medicine')
,('208VP0014X', 'Allopathic & Osteopathic Physicians/Pain Medicine, Interventional Pain Medicine')
,('207RG0100X', 'Allopathic & Osteopathic Physicians/Internal Medicine, Gastroenterology')
,('207R00000X', 'Allopathic & Osteopathic Physicians/Internal Medicine')
,('207RA0401X', 'Allopathic & Osteopathic Physicians/Internal Medicine, Addiction Medicine')
,('207RA0000X', 'Allopathic & Osteopathic Physicians/Internal Medicine, Adolescent Medicine')
,('207RA0001X', 'Allopathic & Osteopathic Physicians/Advanced Heart Failure and Transplant Cardiology')
,('207RA0201X', 'Allopathic & Osteopathic Physicians/Internal Medicine, Allergy & Immunology')
,('207RB0002X', 'Allopathic & Osteopathic Physicians/Internal Medicine, Bariatric Medicine')
,('207RI0001X', 'Allopathic & Osteopathic Physicians/Internal Medicine, Clinical & Laboratory Immunology')
,('207RC0200X', 'Allopathic & Osteopathic Physicians/Internal Medicine, Critical Care Medicine')
,('207RE0101X', 'Allopathic & Osteopathic Physicians/Internal Medicine, Endocrinology, Diabetes, & Metabolism')
,('207RG0300X', 'Allopathic & Osteopathic Physicians/Internal Medicine, Geriatric Medicine')
,('207RH0000X', 'Allopathic & Osteopathic Physicians/Internal Medicine, Hematology')
,('207RH0003X', 'Allopathic & Osteopathic Physicians/Internal Medicine, Hematology & Oncology')
,('207RI0008X', 'Allopathic & Osteopathic Physicians/Internal Medicine, Hepatology')
,('207RH0002X', 'Allopathic & Osteopathic Physicians/Internal Medicine, Hospice and Palliative Medicine')
,('207RI0200X', 'Allopathic & Osteopathic Physicians/Internal Medicine, Infectious Disease')
,('207RM1200X', 'Allopathic & Osteopathic Physicians/Internal Medicine, Magnetic Resonance Imaging (MRI)')
,('207RX0202X', 'Allopathic & Osteopathic Physicians/Internal Medicine, Medical Oncology')
,('207RN0300X', 'Allopathic & Osteopathic Physicians/Internal Medicine, Nephrology')
,('207RP1001X', 'Allopathic & Osteopathic Physicians/Internal Medicine, Pulmonary Disease')
,('207RR0500X', 'Allopathic & Osteopathic Physicians/Internal Medicine, Rheumatology')
,('207RS0012X', 'Allopathic & Osteopathic Physicians/Internal Medicine, Sleep Medicine')
,('207RS0010X', 'Allopathic & Osteopathic Physicians/Internal Medicine, Sports Medicine')
,('207RT0003X', 'Allopathic & Osteopathic Physicians/Internal Medicine, Transplant Hepatology')
,('204D00000X', 'Allopathic & Osteopathic Physicians/Neuromusculoskeletal Medicine & OMM')
,('204C00000X', 'Allopathic & Osteopathic Physicians/Neuromusculoskeletal Medicine, Sports Medicine')
,('2084N0400X', 'Allopathic & Osteopathic Physicians/Psychiatry and Neurology, Neurology')
,('2084N0402X', 'Allopathic & Osteopathic Physicians/Psychiatry and Neurology, Neurology with Special Qualifications in Child Neurology')
,('2084A2900X', 'Allopathic & Osteopathic Physicians/Psychiatry & Neurology/Neurocritical Care')
,('235Z00000X', 'Speech, Language and Hearing Service Providers')
,('207V00000X', 'Allopathic & Osteopathic Physicians/Obstetrics & Gynecology')
,('207VB0002X', 'Allopathic & Osteopathic Physicians/Obstetrics & Gynecology, Bariatric Medicine')
,('207VC0200X', 'Allopathic & Osteopathic Physicians/Obstetrics & Gynecology, Critical Care Medicine')
,('207VF0040X', 'Allopathic & Osteopathic Physicians/Obstetrics & Gynecology, Female Pelvic Medicine and Reconstructive Surgery')
,('207VX0201X', 'Allopathic & Osteopathic Physicians/Obstetrics & Gynecology, Gynecologic Oncology')
,('207VG0400X', 'Allopathic & Osteopathic Physicians/Obstetrics & Gynecology, Gynecology')
,('207VH0002X', 'Allopathic & Osteopathic Physicians/Obstetrics & Gynecology, Hospice and Palliative Medicine')
,('207VM0101X', 'Allopathic & Osteopathic Physicians/Obstetrics & Gynecology, Maternal & Fetal Medicine')
,('207VX0000X', 'Allopathic & Osteopathic Physicians/Obstetrics & Gynecology, Obstetrics')
,('207VE0102X', 'Allopathic & Osteopathic Physicians/Obstetrics & Gynecology, Reproductive Endocrinology')
,('2084H0002X', 'Allopathic & Osteopathic Physicians/Surgery/Hospice and Palliative Medicine, Neuropsychiatry')
,('207PH0002X', 'Allopathic & Osteopathic Physicians/Surgery/Hospice and Palliative Medicine, Emergency Medicine')
,('207W00000X', 'Allopathic & Osteopathic Physicians/Ophthalmology')
,('207WX0009X', 'Allopathic & Osteopathic Physicians/Ophthalmology, Glaucoma Specialist')
,('207WX0200X', 'Allopathic & Osteopathic Physicians/Ophthalmic Plastic and Reconstructive Surgery')
,('207WX0107X', 'Allopathic & Osteopathic Physicians/Ophthalmology, Retina Specialist')
,('207WX0108X', 'Allopathic & Osteopathic Physicians/Ophthalmology, Uveitis and Ocular Inflammatory Disease')
,('207WX0109X', 'Allopathic & Osteopathic Physicians/Ophthalmology/Neuro-ophthalmology')
,('207WX0110X', 'Allopathic & Osteopathic Physicians/Ophthalmology/Pediatric Ophthalmology and Strabismus Specialist')
,('1223S0112X', 'Allopathic & Osteopathic Physicians/Ophthalmology, Dental Providers/Dentist, Oral & Maxillofacial Surgery')
,('207RC0001X', 'Allopathic & Osteopathic Physicians/Internal Medicine, Clinical Cardiatric Electrophysiology')
,('207ZP0101X', 'Allopathic & Osteopathic Physicians/Pathology, Anatomic Pathology')
,('207ZP0102X', 'Allopathic & Osteopathic Physicians/Pathology, Anatomic Pathology & Clinical Pathology')
,('207ZB0001X', 'Allopathic & Osteopathic Physicians/Pathology, Blood Banking & Transfusion Medicine')
,('207ZP0104X', 'Allopathic & Osteopathic Physicians/Pathology, Chemical Pathology')
,('207ZC0006X', 'Allopathic & Osteopathic Physicians/Pathology, Clinical Pathology')
,('207ZP0105X', 'Allopathic & Osteopathic Physicians/Pathology, Clinical Pathology/Laboratory Medicine')
,('207ZC0500X', 'Allopathic & Osteopathic Physicians/Pathology, Cytopathology')
,('207ZD0900X', 'Allopathic & Osteopathic Physicians/Pathology, Dermapathology')
,('207ZF0201X', 'Allopathic & Osteopathic Physicians/Pathology, Forensic Pathology')
,('207ZH0000X', 'Allopathic & Osteopathic Physicians/Pathology, Hematology')
,('207ZI0100X', 'Allopathic & Osteopathic Physicians/Pathology, Immunopathology')
,('207ZM0300X', 'Allopathic & Osteopathic Physicians/Pathology, Medical Microbiology')
,('207ZP0007X', 'Allopathic & Osteopathic Physicians/Pathology, Molecular Genetic Pathology')
,('207ZN0500X', 'Allopathic & Osteopathic Physicians/Pathology, Neuropathology')
,('207ZP0213X', 'Allopathic & Osteopathic Physicians/Pathology, Pediatric Pathology')
,('207PS0010X', 'Allopathic & Osteopathic Physicians/Emergency Medicine, Sports Medicine')
,('2080S0010X', 'Allopathic & Osteopathic Physicians/Pediatrics, Sports Medicine')
,('2081P0301X', 'Allopathic & Osteopathic Physicians/Physical Medicine & Rehabilitation, Brain Injury')
,('2081S0010X', 'Allopathic & Osteopathic Physicians/Physical Medicine & Rehabilitation, Sports Medicine')
,('2083S0010X', 'Allopathic & Osteopathic Physicians/Preventive Medicine, Sports Medicine')
,('2084S0010X', 'Allopathic & Osteopathic Physicians/ Psychiatry & Neurology, Sports Medicine')
,('208100000X', 'Allopathic & Osteopathic Physicians/Physical Medicine & Rehabilitation')
,('2081H0002X', 'Allopathic & Osteopathic Physicians/Physical Medicine & Rehabilitation, Hospice and Palliative Medicine')
,('2081N0008X', 'Allopathic & Osteopathic Physicians/Physical Medicine & Rehabilitation, Neuromuscular Medicine')
,('2081P2900X', 'Allopathic & Osteopathic Physicians/Physical Medicine & Rehabilitation, Pain Medicine')
,('2081P0010X', 'Allopathic & Osteopathic Physicians/Physical Medicine & Rehabilitation, Pediatric Rehabilitation Medicine')
,('2081P0004X', 'Allopathic & Osteopathic Physicians/Physical Medicine & Rehabilitation, Spinal Cord Injury Medicine')
,('2084P0800X', 'Allopathic & Osteopathic Physicians/Psychiatry')
,('2084P0301X', 'Allopathic & Osteopathic Physicians/Psychiatry & Neurology/Respiratory, Developmental, Rehabilitative and Restorative Service , Brain Injury Medicine')
,('2085R0202X', 'Allopathic & Osteopathic Physicians/Radiology, Diagnostic Radiology')
,('367H00000X', 'Physician Assistants & Advanced Practice Nursing Providers/Anesthesiologist Assistant')
,('208800000X', 'Allopathic & Osteopathic Physicians/Urology')
,('2088P0231X', 'Allopathic & Osteopathic Physicians/Urology, Pediatric Urology')
,('2088F0040X', 'Female Pelvic Medicine & Reconstructive Surgery')
,('111N00000X', 'Chiropractic Providers/Chiropractor')
,('111NI0013X', 'Chiropractic Providers/Chiropractor, Independent Medical Examiner')
,('111NI0900X', 'Chiropractic Providers/Chiropractor, Internist')
,('111NN0400X', 'Chiropractic Providers/Chiropractor, Neurology')
,('111NN1001X', 'Chiropractic Providers/Chiropractor, Nutrition')
,('111NX0100X', 'Chiropractic Providers/Chiropractor, Occupational Medicine')
,('111NX0800X', 'Chiropractic Providers/Chiropractor, Orthopedic')
,('111NP0017X', 'Chiropractic Providers/Chiropractor, Pediatric Chiropractor')
,('111NR0200X', 'Chiropractic Providers/Chiropractor, Radiology')
,('111NR0400X', 'Chiropractic Providers/Chiropractor, Rehabilitation')
,('111NS0005X', 'Chiropractic Providers/Chiropractor, Sports Physician')
,('111NT0100X', 'Chiropractic Providers/Chiropractor, Thermography')
,('207U00000X', 'Allopathic & Osteopathic Physicians/Nuclear Medicine')
,('207UN0903X', 'Allopathic & Osteopathic Physicians/Nuclear Medicine, In Vivo & In Vitro Nuclear Medicine')
,('207UN0901X', 'Allopathic & Osteopathic Physicians/Nuclear Medicine, Nuclear Cardiology')
,('207UN0902X', 'Allopathic & Osteopathic Physicians/Nuclear Medicine, Nuclear Imaging & Therapy')
,('208000000X', 'Allopathic & Osteopathic Physicians/Pediatrics')
,('2080A0000X', 'Allopathic & Osteopathic Physicians/Pediatrics, Adolescent Medicine')
,('2080I0007X', 'Allopathic & Osteopathic Physicians/Pediatrics, Clinical & Laboratory Immunology')
,('2080P0006X', 'Allopathic & Osteopathic Physicians/Pediatrics, Developmental–Behavioral Pediatrics')
,('2080H0002X', 'Allopathic & Osteopathic Physicians/Pediatrics, Hospice and Palliative Medicine')
,('2080T0002X', 'Allopathic & Osteopathic Physicians/Pediatrics, Medical Toxicology')
,('2080N0001X', 'Allopathic & Osteopathic Physicians/Pediatrics, Neonatal-Perinatal Medicine')
,('2080P0008X', 'Allopathic & Osteopathic Physicians/Pediatrics, Neurodevelopmental Disabilities')
,('2080P0201X', 'Allopathic & Osteopathic Physicians/Pediatrics, Pediatric Allergy & Immunology')
,('2080P0202X', 'Allopathic & Osteopathic Physicians/Pediatrics, Pediatric Cardiology')
,('2080P0203X', 'Allopathic & Osteopathic Physicians/Pediatrics, Pediatric Critical Care Medicine')
,('2080P0204X', 'Allopathic & Osteopathic Physicians/Pediatrics, Pediatric Emergency Medicine')
,('2080P0205X', 'Allopathic & Osteopathic Physicians/Pediatrics, Pediatric Endocrinology')
,('2080P0206X', 'Allopathic & Osteopathic Physicians/Pediatrics, Pediatric Gastroenterology')
,('2080P0207X', 'Allopathic & Osteopathic Physicians/Pediatrics, Pediatric Hematology-Oncology')
,('2080P0208X', 'Allopathic & Osteopathic Physicians/Pediatrics, Pediatric Infectious Diseases')
,('2080P0210X', 'Allopathic & Osteopathic Physicians/Pediatrics, Pediatric Nephrology')
,('2080P0214X', 'Allopathic & Osteopathic Physicians/Pediatrics, Pediatric Pulmonology')
,('2080P0216X', 'Allopathic & Osteopathic Physicians/Pediatrics, Pediatric Rheumatology')
,('2080T0004X', 'Allopathic & Osteopathic Physicians/Pediatrics, Pediatric Transplant Hepatology')
,('2080S0012X', 'Allopathic & Osteopathic Physicians/Pediatrics, Sleep Medicine')
,('152W00000X', 'Eye and Vision Service Providers/Optometrist')
,('152WC0802X', 'Eye and Vision Service Providers/Optometrist, Corneal and Contact Management')
,('152WL0500X', 'Eye and Vision Service Providers/Optometrist, Low Vision Rehabilitation')
,('152WX0102X', 'Eye and Vision Service Providers/Optometrist, Occupational Vision')
,('152WP0200X', 'Eye and Vision Service Providers/Optometrist, Pediatrics')
,('152WS0006X', 'Eye and Vision Service Providers/Optometrist, Sports Vision')
,('152WV0400X', 'Eye and Vision Service Providers/Optometrist, Vision Therapy')
,('367A00000X', 'Physician Assistants & Advanced Practice Nursing Providers/Midwife, Certified Nurse')
,('367500000X', 'Physician Assistants & Advanced Practice Nursing Providers/Nurse Anesthetist, Certified Registered')
,('261QR0208X', 'Ambulatory Health Care Facilities/Clinic-Center, Radiology, Mammography')
,('261QR0207X', 'Ambulatory Health Care Facilities/Clinic-Center, Radiology, Mobile Mammography')
,('293D00000X', 'Laboratories/Physiological Laboratory')
,('213E00000X', 'Podiatric Medicine & Surgery Service Providers/Podiatrist')
,('213ES0103X', 'Podiatric Medicine & Surgery Service Providers/Podiatrist, Foot & Ankle Surgery')
,('213ES0131X', 'Podiatric Medicine & Surgery Service Providers/Podiatrist, Foot Surgery')
,('213EG0000X', 'Podiatric Medicine & Surgery Service Providers/Podiatrist, General Practice')
,('213EP1101X', 'Podiatric Medicine & Surgery Service Providers/Podiatrist, Primary Podiatric Medicine')
,('213EP0504X', 'Podiatric Medicine & Surgery Service Providers/Podiatrist, Public Medicine')
,('213ER0200X', 'Podiatric Medicine & Surgery Service Providers/Podiatrist, Radiology')
,('213ES0000X', 'Podiatric Medicine & Surgery Service Providers/Podiatrist, Sports Medicine')
,('261QA1903X', 'Ambulatory Health Care Facilities/Clinic-Center, Ambulatory Surgical')
,('363L00000X', 'Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner')
,('363LA2100X', 'Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner, Acute Care')
,('363LA2200X', 'Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner, Adult Health')
,('363LC1500X', 'Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner, Community Health')
,('363LC0200X', 'Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner, Critical Care Medicine')
,('363LF0000X', 'Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner, Family')
,('363LG0600X', 'Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner, Gerontology')
,('363LN0000X', 'Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner, Neonatal')
,('363LN0005X', 'Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner, Neonatal, Critical Care')
,('363LX0001X', 'Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner, Obstetrics & Gynecology')
,('363LX0106X', 'Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner, Occupational Health')
,('363LP0200X', 'Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner, Pediatrics')
,('363LP0222X', 'Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner, Pediatrics, Critical Care')
,('363LP1700X', 'Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner, Perinatal')
,('363LP2300X', 'Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner, Primary Care')
,('363LP0808X', 'Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner, Psychiatric/Mental Health')
,('363LS0200X', 'Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner, School')
,('363LW0102X', 'Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner, Women’s Health')
,('335E00000X', 'Suppliers/Prosthetic/Orthotic Supplier')
,('332B00000X', 'Suppliers/Durable Medical Equipment & Medical Supplies')
,('222Z00000X', 'Respiratory, Developmental, Rehabilitative, and Restorative Service Providers/Orthotist')
,('224P00000X', 'Respiratory, Developmental, Rehabilitative, and Restorative Service Providers/Prosthetist')
,('229N00000X', 'Respiratory, Developmental, Rehabilitative, and Restorative Service Providers/Anaplastologist')
,('333600000X', 'Suppliers/Pharmacy')
,('3336C0002X', 'Suppliers/Pharmacy, Clinic Pharmacy')
,('3336C0003X', 'Suppliers/Pharmacy, Community/Retail Pharmacy')
,('3336C0004X', 'Suppliers/Pharmacy, Compounding Pharmacy')
,('3336H0001X', 'Suppliers/Pharmacy, Home Infusion Therapy Pharmacy')
,('3336I0012X', 'Suppliers/Pharmacy, Institutional Pharmacy')
,('3336L0003X', 'Suppliers/Pharmacy, Long-term Care Pharmacy')
,('3336M0002X', 'Suppliers/Pharmacy, Mail Order Pharmacy')
,('3336M0003X', 'Suppliers/Pharmacy, Managed Care Organization Pharmacy')
,('3336N0007X', 'Suppliers/Pharmacy, Nuclear Pharmacy')
,('3336S0011X', 'Suppliers/Pharmacy, Specialty Pharmacy')
,('341600000X', 'Transportation Services/Ambulance')
,('3416A0800X', 'Transportation Services/Ambulance, Air Transport')
,('3416L0300X', 'Transportation Services/Ambulance, Land Transport')
,('3416S0300X', 'Transportation Services/Ambulance, Water Transport')
,('251K00000X', 'Agencies/Public Health or Welfare')
,('251V00000X', 'Agencies/Voluntary or Charitable')
,('103T00000X', 'Behavioral Health & Social Service Providers/Psychologist')
,('103TA0400X', 'Behavioral Health & Social Service Providers/Psychologist, Addiction (Substance Abuse Disorder)')
,('103TA0700X', 'Behavioral Health & Social Service Providers/Psychologist, Adult Development & Aging')
,('103TC0700X', 'Behavioral Health & Social Service Providers/Psychologist, Clinical')
,('103TC2200X', 'Behavioral Health & Social Service Providers/Psychologist, Clinical Child & Adolescent')
,('103TB0200X', 'Behavioral Health & Social Service Providers/Psychologist, Cognitive & Behavioral')
,('103TC1900X', 'Behavioral Health & Social Service Providers/Psychologist, Counseling')
,('103TE1000X', 'Behavioral Health & Social Service Providers/Psychologist, Educational')
,('103TE1100X', 'Behavioral Health & Social Service Providers/Psychologist, Exercise & Sports')
,('103TF0000X', 'Behavioral Health & Social Service Providers/Psychologist, Family')
,('103TF0200X', 'Behavioral Health & Social Service Providers/Psychologist, Forensic')
,('103TP2701X', 'Behavioral Health & Social Service Providers/Psychologist, Group Psychotherapy')
,('103TH0004X', 'Behavioral Health & Social Service Providers/Psychologist, Health')
,('103TH0100X', 'Behavioral Health & Social Service Providers/Psychologist, Health Service')
,('103TM1700X', 'Behavioral Health & Social Service Providers/Psychologist, Men & Masculinity')
,('103TM1800X', 'Behavioral Health & Social Service Providers/Psychologist, Mental Retardation & Developmental Disabilities')
,('103TP0016X', 'Behavioral Health & Social Service Providers/Psychologist, Prescribing (Medical)')
,('103TP0814X', 'Behavioral Health & Social Service Providers/Psychologist, Psychoanalysis')
,('103TP2700X', 'Behavioral Health & Social Service Providers/Psychologist, Psychotherapy')
,('103TR0400X', 'Behavioral Health & Social Service Providers/Psychologist, Rehabilitation')
,('103TS0200X', 'Behavioral Health & Social Service Providers/Psychologist, School')
,('103TW0100X', 'Behavioral Health & Social Service Providers/Psychologist, Women')
,('106E00000X', 'Behavioral Health & Social Service Providers/Assistant Behavior Analyst')
,('106S00000X', 'Behavioral Health & Social Service Providers/Technician')
,('335V00000X', 'Suppliers/Portable X-Ray Supplier')
,('231H00000X', 'Speech, Language and Hearing Service Providers/Audiologist')
,('231HA2400X', 'Speech, Language and Hearing Service Providers/Audiologist, Assistive Technology Practitioner')
,('225100000X', 'Respiratory, Developmental, Rehabilitative & Restorative Service Providers/Physical Therapist')
,('2251C2600X', 'Respiratory, Developmental, Rehabilitative & Restorative Service Providers/Physical Therapist, Cardiopulmonary')
,('2251E1300X', 'Respiratory, Developmental, Rehabilitative & Restorative Service Providers/Physical Therapist, Electrophysiology, Clinical')
,('2251E1200X', 'Respiratory, Developmental, Rehabilitative & Restorative Service Providers/Physical Therapist, Ergonomics')
,('2251G0304X', 'Respiratory, Developmental, Rehabilitative & Restorative Service Providers/Physical Therapist, Geriatrics')
,('2251H1200X', 'Respiratory, Developmental, Rehabilitative & Restorative Service Providers/Physical Therapist, Hand')
,('2251H1300X', 'Respiratory, Developmental, Rehabilitative & Restorative Service Providers/Physical Therapist, Human Factors')
,('2251N0400X', 'Respiratory, Developmental, Rehabilitative & Restorative Service Providers/Physical Therapist, Neurology')
,('2251X0800X', 'Respiratory, Developmental, Rehabilitative & Restorative Service Providers/Physical Therapist, Orthopedic')
,('2251P0200X', 'Respiratory, Developmental, Rehabilitative & Restorative Service Providers/Physical Therapist, Pediatrics')
,('2251S0007X', 'Respiratory, Rehabilitative & Restorative Service Providers/Physical Therapist, Sports')
,('225X00000X', 'Respiratory, Developmental, Rehabilitative & Restorative Service Providers/Occupational Therapist')
,('225XR0403X', 'Respiratory, Developmental, Rehabilitative & Restorative Service Providers/Occupational Therapist, Driving and Community Mobility')
,('225XE0001X', 'Respiratory, Developmental, Rehabilitative & Restorative Service Providers/Occupational Therapist, Environmental Modification')
,('225XE1200X', 'Respiratory, Developmental, Rehabilitative & Restorative Service Providers/Occupational Therapist, Ergonomics')
,('225XF0002X', 'Respiratory, Developmental, Rehabilitative & Restorative Service Providers/Occupational Therapist, Feeding, Eating &Swallowing')
,('225XG0600X', 'Respiratory, Developmental, Rehabilitative & Restorative Service Providers/Occupational Therapist, Gerontology')
,('225XH1200X', 'Respiratory, Developmental, Rehabilitative & Restorative Service Providers/Occupational Therapist, Hand')
,('225XH1300X', 'Respiratory, Developmental, Rehabilitative & Restorative Service Providers/Occupational Therapist, Human Factors')
,('225XL0004X', 'Respiratory, Developmental, Rehabilitative & Restorative Service Providers/Occupational Therapist, Low Vision')
,('225XM0800X', 'Respiratory, Developmental, Rehabilitative & Restorative Service Providers/Occupational Therapist, Mental Health')
,('225XN1300X', 'Respiratory, Developmental, Rehabilitative & Restorative Service Providers/Occupational Therapist, Neurorehabilitation')
,('225XP0200X', 'Respiratory, Developmental, Rehabilitative & Restorative Service Providers/Occupational Therapist, Pediatrics')
,('225XP0019X', 'Respiratory, Developmental, Rehabilitative & Restorative Service Providers/Occupational Therapist, Physical Rehabilitation')
,('291U00000X', 'Laboratories/Clinical Medical Laboratory')
,('261QM1300X', 'Ambulatory Health Care Facilities/Clinic/Center, Multi-Specialty')
,('261QP2000X', 'Ambulatory Health Care Facilities/Clinic/Center, Physical Therapy')
,('193200000X', 'Group/Multi-Specialty')
,('261Q00000X', 'Ambulatory Health Care Facilities/Clinic/Center, Multi-Specialty')
,('193400000X', 'Group/Single-Specialty')
,('133V00000X', 'Dietary & Nutritional Service Providers/Dietician, Registered')
,('133VN1006X', 'Dietary & Nutritional Service Providers/Dietician, Registered, Nutrition, Metabolic')
,('133VN1004X', 'Dietary & Nutritional Service Providers/Dietician, Registered, Nutrition, Pediatric')
,('133VN1005X', 'Dietary & Nutritional Service Providers/Dietician, Registered, Nutrition, Renal')
,('208VP0000X', 'Allopathic & Osteopathic Physicians/Pain Medicine, Pain Medicine')
,('261QR0200X', 'Ambulatory Health Care Facilities/Clinic/Center, Radiology')
,('247200000X', 'Technologists, Technicians & Other Technical Service Providers/Technician, Other')
,('2084A0401X', 'Allopathic & Osteopathic Physicians/Psychiatry & Neurology, Addiction Medicine')
,('1041C0700X', 'Behavioral Health & Social Service Providers/Social Worker, Clinical')
,('2083A0100X', 'Allopathic & Osteopathic Physicians/Preventive Medicine, Aerospace Medicine')
,('2083T0002X', 'Allopathic & Osteopathic Physicians/Preventive Medicine, Medical Toxicology')
,('2083X0100X', 'Allopathic & Osteopathic Physicians/Preventive Medicine, Occupational Medicine')
,('2083P0500X', 'Allopathic & Osteopathic Physicians/Preventive Medicine,  Preventive Medicine/Occupational Environmental Medicine')
,('2083P0901X', 'Allopathic & Osteopathic Physicians/Preventive Medicine, Public Health & General Preventive Medicine')
,('2083P0011X', 'Allopathic & Osteopathic Physicians/Preventive Medicine, Undersea and Hyperbaric Medicine')
,('2084P0802X', 'Allopathic & Osteopathic Physicians/ Psychiatry & Neurology, Addiction Psychiatry')
,('2084B0002X', 'Allopathic & Osteopathic Physicians/ Psychiatry & Neurology, Bariatric Medicine')
,('2084P0804X', 'Allopathic & Osteopathic Physicians/ Psychiatry & Neurology, Child & Adolescent Psychiatry')
,('2084N0600X', 'Allopathic & Osteopathic Physicians/ Psychiatry & Neurology, Clinical Neurophysiology')
,('2084D0003X', 'Allopathic & Osteopathic Physicians/ Psychiatry & Neurology, Diagnostic Neuroimaging')
,('2084F0202X', 'Allopathic & Osteopathic Physicians/ Psychiatry & Neurology, Forensic Psychiatry')
,('2084P0805X', 'Allopathic & Osteopathic Physicians/ Psychiatry & Neurology, Geriatric Psychiatry')
,('2084P0005X', 'Allopathic & Osteopathic Physicians/ Psychiatry & Neurology, Neurodevelopmental Disabilities')
,('2084N0008X', 'Allopathic & Osteopathic Physicians/ Psychiatry & Neurology, Neuromuscular Medicine')
,('2084P2900X', 'Allopathic & Osteopathic Physicians/ Psychiatry & Neurology, Pain Medicine')
,('2084P0015X', 'Allopathic & Osteopathic Physicians/ Psychiatry & Neurology, Psychosomatic Medicine')
,('2084S0012X', 'Allopathic & Osteopathic Physicians/ Psychiatry & Neurology, Sleep Medicine')
,('2084V0102X', 'Allopathic & Osteopathic Physicians/ Psychiatry & Neurology, Vascular Neurology')
,('364S00000X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist')
,('364SA2100X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Acute Care')
,('364SA2200X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Adult Health')
,('364SC2300X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Chronic Care')
,('364SC1501X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Community Health/Public Health')
,('364SC0200X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Critical Care Medicine')
,('364SE0003X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Emergency')
,('364SE1400X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Ethics')
,('364SF0001X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Family Health')
,('364SG0600X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Gerontology')
,('364SH1100X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Holistic')
,('364SH0200X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Home Health')
,('364SI0800X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Informatics')
,('364SL0600X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Long-term Care')
,('364SM0705X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Medical-Surgical')
,('364SN0000X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Neonatal')
,('364SN0800X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Neuroscience')
,('364SX0106X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Occupational Health')
,('364SX0200X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Oncology')
,('364SX0204X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Oncology, Pediatrics')
,('364SP0200X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Pediatrics')
,('364SP1700X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Perinatal')
,('364SP2800X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Perioperative')
,('364SP0808X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Psychiatric/Mental Health')
,('364SP0809X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Psychiatric/Mental Health, Adult')
,('364SP0807X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Psychiatric/Mental Health, Child & Adolescent')
,('364SP0810X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Psychiatric/Mental Health, Child & Family')
,('364SP0811X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Psychiatric/Mental Health, Chronically Ill')
,('364SP0812X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Psychiatric/Mental Health, Community')
,('364SP0813X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Psychiatric/Mental Health, Geropsychiatric')
,('364SR0400X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Rehabilitation')
,('364SS0200X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, School')
,('364ST0500X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Transplantation')
,('364SW0102X', 'Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist, Women’s Health')
,('2085R0001X', 'Allopathic & Osteopathic Physicians/Radiology, Radiation Oncology')
,('207P00000X', 'Allopathic & Osteopathic Physicians/Emergency Medicine')
,('207PE0004X', 'Allopathic & Osteopathic Physicians/Emergency Medicine, Emergency Medical Services')
,('207PT0002X', 'Allopathic & Osteopathic Physicians/Emergency Medicine, Medical Toxicology')
,('207PP0204X', 'Allopathic & Osteopathic Physicians/Emergency Medicine, Pediatric Emergency Medicine')
,('207PE0005X', 'Allopathic & Osteopathic Physicians/Emergency Medicine, Undersea and Hyperbaric Medicine')
,('2085R0204X', 'Allopathic & Osteopathic Physicians/Radiology, Vascular and Interventional Radiology')
,('2085H0002X', 'Hospice & Palliative Medicine')
,('156FX1800X', 'Eye & Vision Service Providers/Technician/Technologist, Optician')
,('363A00000X', 'Physician Assistants & Advanced Practice Nursing Providers/Physician Assistant')
,('363AM0700X', 'Physician Assistants & Advanced Practice Nursing Providers/Physician Assistant, Medical')
,('363AS0400X', 'Physician Assistants & Advanced Practice Nursing Providers/Physician Assistant, Surgical')
,('282N00000X', 'Hospitals/General Acute Care Hospital')
,('282NC2000X', 'Hospitals/General Acute Care Hospital, Children')
,('282E00000X', 'Hospitals/Long Term Care Hospital')
,('283Q00000X', 'Hospitals/Psychiatric Hospital')
,('283X00000X', 'Hospitals/Rehabilitation Hospital')
,('2843000000X', 'Hospitals/Special(ty) Hospital')
,('275N00000X', 'Hospital Units/Medicare Defined Swing Bed Unit')
,('273R00000X', 'Hospital Units/Psychiatric Unit')
,('273Y00000X', 'Hospital Units/Rehabilitation Unit')
,('284300000X', 'Hospitals/Special(ty) Hospital')
,('282NC0060X', 'Hospitals/General Acute Care Hospital, Critical Access')
,('314000000X', 'Nursing and Custodial Care Facilities/Skilled Nursing Facility')
,('313M00000X', 'Nursing and Custodial Care Facilities/Nursing Facility')
,('251E00000X', 'Agencies/Home Health')
,('1835C0205X', 'Suppliers/Pharmacy, Critical Care')
,('1835P0200X', 'Suppliers/Pharmacy, Pediatrics')
,('332BX2000X', 'Suppliers/Durable Medical Equipment & Medical Supplies, Oxygen Equipment & Supplies')
,('261QR0400X', 'Ambulatory Health Care Facilities/Clinic/Center, Rehabilitation')
,('335U00000X', 'Suppliers/Organ Procurement Organization')
,('261QM0801X', 'Ambulatory Health Care Facilities/Clinic/Center, Mental Health')
,('261QR0401X', 'Ambulatory Health Care Facilities/Clinic/Center, Rehabilitation, Comprehensive Outpatient Rehabilitation Facility (CORF)')
,('261QE0700X', 'Ambulatory Health Care Facilities/End-Stage Renal Disease (ESRD) Treatment')
,('261QF0400X', 'Ambulatory Health Care Facilities/Federally Qualified Health Center (FQHC)')
,('251G00000X', 'Agencies/Hospice Care, Community Based')
,('291900000X', 'Laboratories/Military Clinical Medical Laboratory')
,('282J00000X', 'Hospitals/Religious Non-medical Health Care Institution')
,('261QR1300X', 'Ambulatory Health Care Facilities/Clinic/Center, Rural Health')
,('207RI0011X', 'Allopathic & Osteopathic Physicians/Internal Medicine, Interventional Cardiology')

GO

ALTER PROCEDURE [dbo].[SearchNpi] @NpiNumber VARCHAR(10) = NULL
	,@FirstName VARCHAR(50) = NULL
	,@LastName VARCHAR(50) = NULL
	,@State VARCHAR(20) = NULL
AS
IF (
		@NpiNumber IS NULL
		AND @FirstName IS NULL
		AND @LastName IS NULL
		AND @State IS NULL
		) THROW 70001
	,'At least one parameter should be passed'
	,1;
	SELECT 
			Id
			,CreatedAt
			,UpdatedAt
			,Npi
			,EntityTypeCode
			,EmployerIdentificationNumber
			,ProviderOrganizationName
			,ProviderLastName
			,ProviderFirstName
			,ProviderMiddleName
			,ProviderNamePrefixText
			,ProviderNameSuffixText
			,ProviderCredentialText
			,ProviderGenderCode
			,ProviderOtherOrganizationName
			,ProviderOtherOrganizationNameTypeCode
			,ProviderFirstLineBusinessMailingAddress
			,ProviderSecondLineBusinessMailingAddress
			,ProviderBusinessMailingAddressCityName
			,ProviderBusinessMailingAddressStateName
			,ProviderBusinessMailingAddressPostalCode
			,ProviderBusinessMailingAddressCountryCode
			,ProviderBusinessMailingAddressTelephoneNumber
			,ProviderFirstLineBusinessPracticeLocationAddress
			,ProviderSecondLineBusinessPracticeLocationAddress
			,ProviderBusinessPracticeLocationAddressCityName
			,ProviderBusinessPracticeLocationAddressStateName
			,ProviderBusinessPracticeLocationAddressPostalCode
			,ProviderBusinessPracticeLocationAddressCountryCode
			,ProviderBusinessPracticeLocationAddressTelephoneNumber
			,LastUpdateDate
			,HealthcareProviderTaxonomyCode
			,HealthcareProviderTaxonomyDescription
			,ProviderLicenseNumber
			,ProviderLicenseNumberStateCode
	FROM NpiRecords
	LEFT OUTER JOIN
	(
		SELECT
				Code,
				[Description] AS HealthcareProviderTaxonomyDescription
				FROM Taxonomy
	) AS T
	ON T.Code = NpiRecords.HealthcareProviderTaxonomyCode
	WHERE (
			ProviderFirstName = @FirstName
			OR @FirstName IS NULL
			)
		AND (
			ProviderLastName = @LastName
			OR @LastName IS NULL
			)
		AND (
			Npi = @NpiNumber
			OR @NpiNumber IS NULL
			)
		AND (
			ProviderBusinessPracticeLocationAddressStateName = @State
			OR @State IS NULL
			)
			OPTION (RECOMPILE);
GO


ALTER PROCEDURE [dbo].[SearchCms] @NpiNumber VARCHAR(10) = NULL
	,@FirstName VARCHAR(50) = NULL
	,@LastName VARCHAR(50) = NULL
	,@State VARCHAR(20) = NULL
AS
IF (
		@NpiNumber IS NULL
		AND @FirstName IS NULL
		AND @LastName IS NULL
		AND @State IS NULL
		) THROW 70001
	,'At least one parameter should be passed'
	,1;
	SELECT 
			Id
			,CreatedAt
			,Npi
			,ProviderFirstName
			,ProviderLastName
			,ProviderTaxonomyCode
			,ProviderTaxonomyDescription
			,ProviderType
			,LicenseState
			,LicenseNumber
	FROM CmsRecords
	LEFT OUTER JOIN
	(
		SELECT
				Code,
				[Description] AS ProviderTaxonomyDescription
				FROM Taxonomy
	) AS T
	ON T.Code = CmsRecords.ProviderTaxonomyCode
	WHERE (
			ProviderFirstName = @FirstName
			OR @FirstName IS NULL
			)
		AND (
			ProviderLastName = @LastName
			OR @LastName IS NULL
			)
		AND (
			Npi = @NpiNumber
			OR @NpiNumber IS NULL
			)
		AND (
			LicenseState = @State
			OR @State IS NULL
			)
			OPTION (RECOMPILE);
GO
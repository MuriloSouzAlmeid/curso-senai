import { View, ActivityIndicator, StyleSheet, Text } from "react-native";
import { BoxInputField } from "../../components/Box";
import { BoxInputRow, UserContentBox } from "../../components/Box/style";
import { Button } from "../../components/Button/styled";
import { ContainerApp, ContainerForm } from "../../components/Container/style";
import { LinkVoltar } from "../../components/Link/style";
import {
  ButtonTitle,
  EmailUserText,
  UserNamePerfilText,
} from "../../components/Text/style";
import {
  ClinicaContentBox,
  ClinicaImage,
  ContainerLocalConsulta,
} from "./style";
import { useEffect, useRef, useState } from "react";

import MapView, { Marker, PROVIDER_GOOGLE } from "react-native-maps";
import {
  requestForegroundPermissionsAsync, //solikcitar permissao da localização
  getCurrentPositionAsync, //captura a localização atual
  watchPositionAsync, // captura a localização em tempos
  LocationAccuracy, // precisão da captura
} from "expo-location";

import { mapsKey } from "../../utils/MapsKey";
import MapViewDirections from "react-native-maps-directions";
import { api } from "../../services/service";
import { LinkCancel } from "../../components/Link";
import { LoadingIndicator } from "../../components/LoadingIndicator";

export const LocalConsulta = ({ navigation, route }) => {
  const [dataClinic, setDataClinic] = useState(null);
  const [numero, setNumero] = useState({});
  const [cidade, setCidade] = useState({});
  const [logradouro, setLogradouro] = useState({});
  const [coordsClinica, setCoordsClinica] = useState({})
  const [latitude, setLatitude] = useState({});
  const [longitude, setLongitude] = useState({});
  const [finalPosition, setFinalPosition] = useState({});

  const mapReference = useRef(null);

  const [initialPosition, setInitialPosition] = useState(null);

  //DADOS DA CLINICA
  const ClinicaInfo = async () => {
    try {
      //id mocado
      // const id= '4ca5872c-e27d-42dc-81cb-0185b57940c9'
      const retornoGet = await api.get(
        `/Clinica/BuscarPorId?id=${route.params.clinicaId}`
      );
      setNumero(retornoGet.data.endereco.numero);
      setCidade(retornoGet.data.endereco.cidade);
      setLogradouro(retornoGet.data.endereco.logradouro);
      setLatitude(retornoGet.data.endereco.latitude);
      setLongitude(retornoGet.data.endereco.longitude)
      setDataClinic(retornoGet.data);

      //define as coordenadas da clínica
      setCoordsClinica({
        latitude: retornoGet.data.endereco.latitude,
        longitude: retornoGet.data.endereco.longitude
      })
      setFinalPosition(coordsClinica)
    } catch (error) {
      console.log(error);
    }
  };

  const CapturarLocalizacao = async () => {
    const { granted } = await requestForegroundPermissionsAsync();

    if (granted) {
      const currentPosition = await getCurrentPositionAsync();

      setInitialPosition(currentPosition);

    }
  };

  const RecarregarVisualizacaoMapa = async () => {
    if (mapReference.current && initialPosition) {
      await mapReference.current.fitToCoordinates(
        [
          {
            latitude: initialPosition.coords.latitude,
            longitude: initialPosition.coords.longitude,
          },
          {
            latitude: coordsClinica.latitude,
            longitude: coordsClinica.longitude,
          },
        ],
        {
          edgePadding: { top: 60, right: 60, bottom: 60, left: 60 },
          animated: true,
        }
      );
    }
  };

  useEffect(() => {
    CapturarLocalizacao();

    //capturar localmente
    watchPositionAsync({
        accuracy: LocationAccuracy.High,
        timeInterval: 1000,
        distanceInterval: 1
      }, async response => {
        await setInitialPosition(response)
      })

  }, []);

  useEffect(() => {
    if (dataClinic == null) {
      ClinicaInfo();
    }
  }, [dataClinic]);

  useEffect(() => {
    RecarregarVisualizacaoMapa()
  }, [initialPosition])

  return (
    <ContainerLocalConsulta>
      {/* <ClinicaImage
                source={require("../../assets/images/local_consulta_image.png")}
            /> */}
      {
        dataClinic != null && (
        <>
          <View style={styles.container}>
            {initialPosition !== null ? (
              <>
                <MapView
                  ref={mapReference}
                  initialRegion={{
                    latitude: initialPosition.coords.latitude,
                    longitude: initialPosition.coords.longitude,
                    latitudeDelta: 0.005,
                    longitudeDelta: 0.005,
                  }}
                  style={styles.map}
                  customMapStyle={grayMapStyle}
                  provider={PROVIDER_GOOGLE}
                >
                  {/* criando um marcador no mapa */}
                  <Marker
                    coordinate={{
                      latitude: initialPosition.coords.latitude,
                      longitude: initialPosition.coords.longitude,
                    }}
                    title="Exemplo de local"
                    description="Senai Paulo Antonio Skaf"
                    pinColor="blue"

                    // propriedade para alterar o ícone de localização
                    // image={}
                  />

                  <MapViewDirections
                    origin={initialPosition.coords}
                    destination={{
                       latitude: latitude,
                       longitude:longitude,
                      latitudeDelta: 0.005,
                      longitudeDelta: 0.005,
                    }}
                    strokeWidth={5}
                    strokeColor="#496DBA"
                    apikey={mapsKey}
                  />

                  <Marker
                    coordinate={{
                      latitude: latitude,
                      longitude: longitude,
                    }}
                    title="Exemplo de local"
                    description="Senai Paulo Antonio Skaf"
                    pinColor="red"

                    // propriedade para alterar o ícone de localização
                    // image={}
                  />
                </MapView>
              </>
            ) : (
              <LoadingIndicator/>
            )}
          </View>

          <ClinicaContentBox editavel={true}>
            <UserNamePerfilText editavel={true}>
              {dataClinic.nomeFantasia}
            </UserNamePerfilText>
            <EmailUserText editavel={true}>{cidade}</EmailUserText>
          </ClinicaContentBox>

          <ContainerForm>
            <BoxInputField
              labelText={"Endereço:"}
              placeholderText={"Rua da Clínica"}
              inputPerfil
            />

            <BoxInputRow>
              <BoxInputField
                labelText={"Número:"}
                placeholderText={`${numero}`}
                fieldWidth={35}
                inputPerfil
                // fieldValue={numero}
              />
              <BoxInputField
                labelText={"Bairro:"}
                placeholderText={logradouro}
                fieldWidth={57}
                inputPerfil
              />
            </BoxInputRow>
            <LinkCancel onPress={() => navigation.navigate("Main")}>
              Voltar
            </LinkCancel>
          </ContainerForm>
        </>
      )}
    </ContainerLocalConsulta>
  );
};

const styles = StyleSheet.create({
  container: {
    heigh: 324,
    with: "100%",
    backgroundColor: "#fff",
    alignItems: "center",
    justifyContent: "center",
  },
  map: {
    height: 324,
    width: "100%",
  },
});

const grayMapStyle = [
  {
    elementType: "geometry",
    stylers: [
      {
        color: "#E1E0E7",
      },
    ],
  },
  {
    elementType: "geometry.fill",
    stylers: [
      {
        saturation: -5,
      },
      {
        lightness: -5,
      },
    ],
  },
  {
    elementType: "labels.icon",
    stylers: [
      {
        visibility: "on",
      },
    ],
  },
  {
    elementType: "labels.text.fill",
    stylers: [
      {
        color: "#FBFBFB",
      },
    ],
  },
  {
    elementType: "labels.text.stroke",
    stylers: [
      {
        color: "#33303E",
      },
    ],
  },
  {
    featureType: "administrative",
    elementType: "geometry",
    stylers: [
      {
        color: "#fbfbfb",
      },
    ],
  },
  {
    featureType: "administrative.country",
    elementType: "labels.text.fill",
    stylers: [
      {
        color: "#fbfbfb",
      },
    ],
  },
  {
    featureType: "administrative.land_parcel",
    stylers: [
      {
        visibility: "on",
      },
    ],
  },
  {
    featureType: "administrative.locality",
    elementType: "labels.text.fill",
    stylers: [
      {
        color: "#fbfbfb",
      },
    ],
  },
  {
    featureType: "poi",
    elementType: "labels.text.fill",
    stylers: [
      {
        color: "#fbfbfb",
      },
    ],
  },
  {
    featureType: "poi.business",
    stylers: [
      {
        visibility: "on",
      },
    ],
  },
  {
    featureType: "poi.park",
    elementType: "geometry",
    stylers: [
      {
        color: "#66DA9F",
      },
    ],
  },
  {
    featureType: "poi.park",
    elementType: "labels.text",
    stylers: [
      {
        visibility: "on",
      },
    ],
  },
  {
    featureType: "poi.park",
    elementType: "labels.text.fill",
    stylers: [
      {
        color: "#fbfbfb",
      },
    ],
  },
  {
    featureType: "poi.park",
    elementType: "labels.text.stroke",
    stylers: [
      {
        color: "#1B1B1B",
      },
    ],
  },
  {
    featureType: "road",
    stylers: [
      {
        visibility: "on",
      },
    ],
  },
  {
    featureType: "road",
    elementType: "geometry.fill",
    stylers: [
      {
        color: "#C6C5CE",
      },
    ],
  },
  {
    featureType: "road",
    elementType: "labels.text.fill",
    stylers: [
      {
        color: "#FBFBFB",
      },
    ],
  },
  {
    featureType: "road.arterial",
    elementType: "geometry",
    stylers: [
      {
        color: "#ACABB7",
      },
    ],
  },
  {
    featureType: "road.highway",
    elementType: "geometry",
    stylers: [
      {
        color: "#8C8A97",
      },
    ],
  },
  {
    featureType: "road.highway.controlled_access",
    elementType: "geometry",
    stylers: [
      {
        color: "#8C8A97",
      },
    ],
  },
  {
    featureType: "road.local",
    elementType: "labels.text.fill",
    stylers: [
      {
        color: "#fbfbfb",
      },
    ],
  },
  {
    featureType: "transit",
    elementType: "labels.text.fill",
    stylers: [
      {
        color: "#fbfbfb",
      },
    ],
  },
  {
    featureType: "water",
    elementType: "geometry",
    stylers: [
      {
        color: "#8EA5D9",
      },
    ],
  },
  {
    featureType: "water",
    elementType: "labels.text.fill",
    stylers: [
      {
        color: "#fbfbfb",
      },
    ],
  },
];